namespace PIS_Vaccination_PI_21_03.Source.Services.Authorize;

public class JwtResponse
{
    public int? UserId { get; set; }
    public string? AccessToken { get; set; }
    public string? Login { get; set; }
    public bool Status { get; set; }
    public DateTime Time { get; set; }
    

    public JwtResponse(int? userId, bool status, string? accessToken, string? login)
    {
        UserId = userId;
        AccessToken = accessToken;
        Login = login;
        Status = status;
        Time = DateTime.Now;
    }
}