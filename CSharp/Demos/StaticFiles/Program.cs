var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

var staticFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFolder");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(staticFolderPath),
    RequestPath = "/StaticFiles"
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Requested file not found in static folders");
});

app.Run();
