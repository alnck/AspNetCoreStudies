using AutoMapper;
using BP.Api.Data.Models;
using BP.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BP.Api.Service
{
  public class ContactService : IContactService
  {
    private readonly IMapper mapper;
    private readonly IHttpClientFactory httpClientFactory;

    public ContactService(IMapper Mapper, IHttpClientFactory HttpClientFactory)
    {
      mapper = Mapper;
      httpClientFactory = HttpClientFactory;
    }

    public  ContactDVO GetContactById(int id)
    {
      // Veritabanından Kaydın Getirilmesi

      Contact dbContact = getDummyContact();

      var client = httpClientFactory.CreateClient("googleapi");

      ContactDVO resultContact = new ContactDVO();

      mapper.Map(dbContact, resultContact);

      //Contact resultContact = mapper.Map<ContactDVO>(dbContact); // Bu şekilde de yazılabilir.

      return resultContact;
    }

    private Contact getDummyContact()
    {
      return new Contact()
      {
        Id = 1,
        FirstName = "Eren",
        LastName = "Alnck",
      };
    }
  }
}
