using System.IdentityModel.Tokens.Jwt;

namespace PIS_Vaccination_PI_21_03.Source.Middleware;

//TODO: пишущий логер
public class LogWriterMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Middleware worked!!!");
        await next(context);
    }
}