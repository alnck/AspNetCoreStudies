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

      //throw new Exception("Test Hatasý");

      return "OK";

    }

    [HttpGet("Student")]
    public Student GetStudent()
    {
      return new Student()
      {
        Id = 1,
        FullName = "Eren Alnck",
      };
    }

    [HttpPost("Student")]
    public String CreateStudent([FromBody]Student student)
    {
      return "Student Created";
    }
  }

  public class Student
  {
    public int Id { get; set; }

    public string FullName { get; set; }
  }
}