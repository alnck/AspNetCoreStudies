using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {

      //throw new Exception("Test Hatas�");

      return "OK";

    }
  }
}