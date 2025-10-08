var builder = WebApplication.CreateBuilder(args); // Create a WebApplication builder
var app = builder.Build(); // Build the WebApplication

// app.MapGet("/", () => "Hello World!"); // Example endpoint (commented out)

app.Run(async context =>
{
    if (context.Request.Query.ContainsKey("id")) // Check if 'id' exists in query string
    {
        await context.Response.WriteAsync(
            $"The ID in the query string is {context.Request.Query["id"]}"); // Write the 'id' value to response
    }

    await context.Response.WriteAsync(
        $"The path is {context.Request.Path.Value}"); // Write the request path to response
});

app.Run(); // Run the application
