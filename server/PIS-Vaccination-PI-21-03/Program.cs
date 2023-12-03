using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PIS_Vaccination_PI_21_03.Source.Middleware;
using PIS_Vaccination_PI_21_03.Source.Services.Authorize;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/api", () => "Server start");

app.UseMiddleware<LogWriterMiddleware>();
app.UseDeveloperExceptionPage();
 
app.UseRouting();
 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();