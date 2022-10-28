using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

namespace CRM.Domain.Services.PasswordHasher
{
    public class PasswordHasherService : IPasswordHasherService
    {
        public string HashPassword(string password)
        {
            throw new NotImplementedException();
        }

        public string PasswordDecodeing(string password)
        {
            IPasswordHasher hasher = new PasswordHasher();

            return "";
        }

        public string PasswordEncodeing(string password)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
