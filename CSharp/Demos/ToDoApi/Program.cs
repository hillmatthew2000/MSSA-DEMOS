var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World from root!");
app.MapGet("/path1", () => "Hello World from path1!");

app.Run();