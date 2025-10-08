var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
 
app.Map("/map", mapApp =>
{
    mapApp.Run(async context =>
    {
        await context.Response.WriteAsync("Hello from the map branch");
    });
});
 
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the main pipeline");
});

app.Run();