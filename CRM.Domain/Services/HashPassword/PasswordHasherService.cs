using System.Security.Cryptography;
using System.Text;

namespace CRM.Domain.Services.NewFolder
{
    public class PasswordHasherService : IPasswordHasherService
    {
        public string PasswordEncodeing(string password)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            using (MD5CryptoServiceProvider md5 = new())
            {
                byte[] data = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

    }
}
