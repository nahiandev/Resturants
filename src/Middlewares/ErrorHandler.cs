
namespace Restaurants.Middlewares
{
    public class ErrorHandler : IMiddleware
    {
        private readonly ILogger<ErrorHandler> _logger;

        public ErrorHandler(ILogger<ErrorHandler> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;

                await context.Response.WriteAsync("It's not you, its us. We're working hard to get things back to normal.");
            }
        }
    }
}
