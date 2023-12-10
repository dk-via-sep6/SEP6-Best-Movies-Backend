using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "API-Key";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;

    }

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {
        // Bypass the API key check for Swagger
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("API Key is missing");
            return;
        }


        //     var apiKey = configuration.GetValue<string>("ApiKey"); // Read from secure storage

        var apiKey = configuration["AuthApiKey:APIKey"];

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Unauthorized client");
            return;
        }

        await _next(context);
    }
}
