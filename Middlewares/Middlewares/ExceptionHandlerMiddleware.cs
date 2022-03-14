namespace Middlewares
{
  public class ExceptionHandlerMiddleware
  {
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> Logger)
    {
      this.next = next;
      logger = Logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      try
      {
        await next.Invoke(httpContext);
      }
      catch (Exception ex)
      {
        logger.LogError(ex.Message);
        throw;
      }
    }
  }
}
