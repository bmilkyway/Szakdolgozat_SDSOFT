using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<bool> Register(string username,string pawssword, string email, string name);
        Task<User> Login(string username, string password);
    }
}
