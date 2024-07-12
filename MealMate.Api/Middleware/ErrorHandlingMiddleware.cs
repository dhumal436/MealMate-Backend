using System.Net;
using System.Text.Json;

namespace MealMate.Api.Middleware;

public class ErrorHandlingMiddleware
{
    // It represents the next piece of middleware in the pipeline, allowing requests to be passed along after one piece of middleware has completed its operations.
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(Exception ex)
        {
            await HandleException(httpContext, ex);
        }
    }

    private static Task HandleException(HttpContext httpContext, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new {error= exception.Message});
        httpContext.Response.StatusCode = (int)code;
        return httpContext.Response.WriteAsync(result);
    }
}
