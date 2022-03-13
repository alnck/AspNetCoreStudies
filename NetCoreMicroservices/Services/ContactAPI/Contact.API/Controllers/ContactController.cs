using Contact.API.Infrastucture;
using Contact.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactController : ControllerBase
  {
    private readonly IContactService contactService;

    public ContactController(IContactService ContactService)
    {
      contactService = ContactService;
    }

    [HttpGet("{id}")]
    public ContactDTO Get(int id)
    {
      return contactService.GetContactById(id);
    }
  }
}
