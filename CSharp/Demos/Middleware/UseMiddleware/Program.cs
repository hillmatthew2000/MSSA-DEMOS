var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Entering the first middleware.\n");
    await next.Invoke();
    await context.Response.WriteAsync("Exiting the first middleware.\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Entering the second middleware.\n");
    await next.Invoke();
    await context.Response.WriteAsync("Exiting the second middleware.\n");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Inside run middleware (end of pipeline)\n");
});

app.Run();