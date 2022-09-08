using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CRM.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDataService<User> dataService;

        public AuthenticationService(IDataService<User> dataService)
        {
            this.dataService = dataService;
        }

        public async Task<User> Login(string username, string password)
        {
            IPasswordHasher hasher = new PasswordHasher();

            User user = await dataService.Login(username, hasher.HashPassword(password));
            return user;
        }

        public async Task<bool> Register(string username, string password, string email, string name)
        {
            IPasswordHasher hasher = new PasswordHasher();
            User user = new User()
            {
                Email = email,
                UserName = username,
                Password = hasher.HashPassword(password),
                Name = name,
                IsActive = false,
                RegistrationDate = DateTime.Now,
                PermissionId = 2



            };
            await dataService.Ceate(user);
            return true;
        }
    }
}
