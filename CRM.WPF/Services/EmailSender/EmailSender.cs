using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WPF.Services.EmailSender
{
    public class EmailSender
    {
        public void forgotPasswordEmail(User user,int code) 
        {
          


            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "sdsoft.helper@gmail.com",
                    Password = "omvxmfyzpfglwehk"

                }

            };
            MailAddress Küldő = new MailAddress("sdsoft.helper@gmail.com");
            MailAddress Fogadó = new MailAddress(user.Email!);
            MailMessage Üzenet = new MailMessage
            {
                From = Küldő,
                Subject = "Elfelejtett jelszó",
                Body = $"Kedes {user.Name}!\nA jelszó visszaállításhoz generált kód: {code}.\nA megváltoztatáshoz kérjük írja be a Hitelesítési kód mezőbe a kódot, majd adja meg új jelszavát.\nTovábbi kérédekkel forduljon az alkalmazás fejlesztőjéhez és üzemeltetőjéhez!\nElérhetőségek: \tgmal: sdsoft.helper@gmail.com\ttelefonszám: +36(30)3074063"
            };
            Üzenet.To.Add(Fogadó);
            Client.SendMailAsync(Üzenet);
        }
        public void succesfullSignIn(User user)
        {



            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "sdsoft.helper@gmail.com",
                    Password = "omvxmfyzpfglwehk"

                }

            };
            MailAddress Küldő = new MailAddress("sdsoft.helper@gmail.com");
            MailAddress Fogadó = new MailAddress(user.Email!);
            MailMessage Üzenet = new MailMessage
            {
                From = Küldő,
                Subject = "Sikeres regisztráció",
                Body = $"Kedes {user.Name}!\nÜdvözöljük a rendszerben! A regisztrációja sikeres volt!\nAmennyiben kérdése van vagy segítségre szorul, forduljon az alkalmazás fejlesztőjéhez és üzemeltetőjéhez!\nElérhetőségek: \tgmal: sdsoft.helper@gmail.com\ttelefonszám: +36(30)3074063"
            };
            Üzenet.To.Add(Fogadó);
            Client.SendMailAsync(Üzenet);
        }
    }

}
