using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Services.PasswordHasher
{
    public interface IPasswordHasherService
    {
        String PasswordEncodeing(string password);
        String PasswordDecodeing(string password);
    }
}
