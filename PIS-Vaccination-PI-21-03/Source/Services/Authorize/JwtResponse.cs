namespace PIS_Vaccination_PI_21_03.Source.Services.Authorize;

public class JwtResponse
{
    public string? AccessToken { get; set; }
    public string? Login { get; set; }
    public bool Status { get; set; }
    public DateTime Time { get; set; }
    

    public JwtResponse(bool status, string? accessToken, string? login)
    {
        AccessToken = accessToken;
        Login = login;
        Status = status;
        Time = DateTime.Now;
    }
}