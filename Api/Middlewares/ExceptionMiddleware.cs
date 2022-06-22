using Models.Exceptions;
using Models.ResponsePayloads;

namespace Api.Middlewares;

/// <summary>
/// Exception middleware.
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Constructor for <see cref="ExceptionMiddleware"/>.
    /// </summary>
    /// <param name="next"><see cref="RequestDelegate"/>.</param>
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invokes request.
    /// </summary>
    /// <param name="httpContext"><see cref="HttpContext"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (CustomException customException)
        {
            await HandleExceptionAsync(httpContext, customException);
        }
        catch
        {
            await HandleExceptionAsync(httpContext);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var errorResponsePayload = new ErrorResponsePayload
        {
            Message = "Something went wrong."
        };
        
        await context.Response.WriteAsync(errorResponsePayload.ToString());
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        CustomException customException)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = customException.GetStatusCode();
        
        var errorResponsePayload = new ErrorResponsePayload
        {
            Message = customException.Message
        };
        
        await context.Response.WriteAsync(errorResponsePayload.ToString());
    }
}