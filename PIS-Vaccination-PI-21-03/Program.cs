var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/api", () => "Server start");

app.UseDeveloperExceptionPage();
 
app.UseRouting();
 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();