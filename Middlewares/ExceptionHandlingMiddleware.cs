namespace Project.UI.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> loggerFactory)
    {
        _next = next;
        _logger = loggerFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unhandled exception occurred while processing the request.");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "An unexpected error occurred.",
                #if DEBUG
                error = e.Message
                #endif
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}