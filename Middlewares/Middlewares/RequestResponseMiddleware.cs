namespace Middlewares
{
  public class RequestResponseMiddleware
  {
    private readonly RequestDelegate next;

    public RequestResponseMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      await next.Invoke(httpContext);
    }
  }

}
