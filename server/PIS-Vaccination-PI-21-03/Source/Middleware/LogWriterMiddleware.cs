using System.IdentityModel.Tokens.Jwt;

namespace PIS_Vaccination_PI_21_03.Source.Middleware;

//TODO: пишущий логер
public class LogWriterMiddleware : IMiddleware
{

    // nixua ne rabotaet
    //TODO: sdelat chtob rabotalo
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)  
    {  
        using (StreamWriter writer = new StreamWriter("/Users/tamanit/Desktop/test.txt"))
        {
            writer.WriteLineAsync("I work!");
        }

        await next(context);
    }
}