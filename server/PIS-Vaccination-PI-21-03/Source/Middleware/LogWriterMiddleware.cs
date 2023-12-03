namespace PIS_Vaccination_PI_21_03.Source.Middleware;

//TODO: пишущий логер
public class LogWriterMiddleware
{
    private readonly RequestDelegate _next;  
    private readonly ILogger<LogWriterMiddleware> _logger;  
    public LogWriterMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)  
    {  
        _next = next;  
        _logger = loggerFactory?.CreateLogger<LogWriterMiddleware>() ??  
                  throw new ArgumentNullException(nameof(loggerFactory));  
    }  
    public async Task InvokeAsync(HttpContext context)  
    {  
        string controllerName = context.Request.RouteValues["controller"].ToString();
        string actionName = context.Request.RouteValues["action"].ToString();
        
        
        
    }
}