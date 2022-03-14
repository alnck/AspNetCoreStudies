using System.Text;

namespace Middlewares
{
  public class RequestResponseMiddleware
  {
    private readonly RequestDelegate next;
    private readonly ILogger<RequestResponseMiddleware> logger;

    public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
    {
      this.next = next;
      this.logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      // Resquest

      var originalBodyStream = httpContext.Response.Body;

      logger.LogInformation($"Query Keys: { httpContext.Request.QueryString}");

      MemoryStream requestBody = new MemoryStream();
      await httpContext.Request.Body.CopyToAsync(requestBody);
      requestBody.Seek(0, SeekOrigin.Begin);
      string requestText = await new StreamReader(requestBody).ReadToEndAsync();
      requestBody.Seek(0, SeekOrigin.Begin);

      var tempStream = new MemoryStream();
      httpContext.Response.Body = tempStream;

      await next.Invoke(httpContext); // Response oluşma satırı

      // Response

      httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
      String responseText = await new StreamReader(httpContext.Response.Body, Encoding.UTF8).ReadToEndAsync();
      httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

      await httpContext.Response.Body.CopyToAsync(originalBodyStream);

      logger.LogInformation($"Request: {requestText}");
      logger.LogInformation($"Response: {responseText}");
    }
  }
}
