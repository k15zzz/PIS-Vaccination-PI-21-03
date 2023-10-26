using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Services.Authorize;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Services.Authorize;

public class AuthorizeService
{
    public static JwtResponse LoginUser(string login, string password)
    {
        UserEntitiesModels? user = null;
        
        using (AppDbContext db = new AppDbContext())
        {
            user = db.Users.FirstOrDefault(p => p.Login == login && p.Password == password);
        }
        
        if(user is null) 
            return new JwtResponse( null, false, null, null);

        var claims = GenerateClaim(user.Id.ToString(), user.Login);

        var encodedJwt = GenerateJwtToken(claims);
 
        return new JwtResponse(user.Id,true, encodedJwt, user.Login);
    }
    
    private static List<Claim> GenerateClaim(string id, string login)
    {
        return new List<Claim>
        {
            new Claim(ClaimTypes.Sid, id),
            new Claim(ClaimTypes.Name, login),
        };
    }
    
    private static string GenerateJwtToken(List<Claim> claims)
    {
        var jwt = new JwtSecurityToken(
            issuer: AuthorizeOptions.ISSUER,
            audience: AuthorizeOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(
                AuthorizeOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}