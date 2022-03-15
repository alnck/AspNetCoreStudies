using BP.Api.Models;
using BP.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace BP.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactController : ControllerBase
  {
    private readonly IConfiguration configuration;
    private readonly IContactService contactService;

    public ContactController(IConfiguration configuration, IContactService contactService)
    {
      this.configuration = configuration;
      this.contactService = contactService;
    }

    [HttpGet]
    public string Get()
    {
      return configuration["ReadMe"].ToString();
    }

    [ResponseCache(Duration = 10)] // 10 sn boyunca cache de tut
    [HttpGet("{id}")]
    public ContactDVO GetContactById(int id)
    {
      return contactService.GetContactById(id);
    }

    [HttpPost]
    public ContactDVO CreateContact(ContactDVO contact)
    {
      // Create contact on DB
      return contact;
    }
  }
}
