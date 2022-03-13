using Contact.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.Infrastucture
{
  public interface IContactService
  {
    public ContactDTO GetContactById(int id);
  };
}
