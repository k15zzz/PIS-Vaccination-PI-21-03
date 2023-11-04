using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PIS_Vaccination_PI_21_03.Source.Services.Authorize;

public class AuthorizeOptions
{
    public const string ISSUER = "vaccination"; // издатель токена
    public const string AUDIENCE = "client"; // потребитель токена
    const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}