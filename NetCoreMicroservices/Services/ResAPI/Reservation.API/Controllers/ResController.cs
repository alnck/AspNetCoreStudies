using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Infrastructure;

namespace Reservation.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ResController : ControllerBase
  {
    private readonly IReservatioService reservatioService;

    public ResController(IReservatioService reservatioService)
    {
      this.reservatioService = reservatioService;
    }

    [HttpGet("{id}")]
    public Reservation.API.Models.ReservationDTO Get(int id)
    {
      return reservatioService.GetResByBkgNumber(id);
    }
  }
}
