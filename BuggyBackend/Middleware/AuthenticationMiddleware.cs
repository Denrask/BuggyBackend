namespace BuggyBackend.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public AuthenticationMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // if (context.Request.Path.StartsWithSegments("/testoperator", StringComparison.InvariantCultureIgnoreCase))
        //     Thread.Sleep(2000);

        if(true)
            await _next(context);
    }
}