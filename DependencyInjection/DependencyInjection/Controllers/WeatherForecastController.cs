using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly INumGenerator2 numGenerator2;
    private readonly INumGenerator numGenerator;

    public WeatherForecastController( INumGenerator2 numGenerator2, INumGenerator numGenerator)
    {
      this.numGenerator2 = numGenerator2;
      this.numGenerator = numGenerator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {
      int random = numGenerator.RandomValue;
      int random1 = numGenerator2.RandomValue;
      int random2 = numGenerator2.GetNumGeneratorRandomNumber();


      return $"NumGenerator.RandomValue: {random}, NumGenerator2.RandomValue: {random1}, NumGenerator2.NumGenerator.RandomValue: {random2}";
    }
  }
}