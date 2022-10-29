using System.Net;
using System.Net.Mail;

using CRM.Domain.Models;

namespace CRM.WPF.Services.EmailSender
{
    public class EmailSender
    {

        /// <summary>
        /// SMTP server
        /// </summary>
        private readonly
            SmtpClient SmtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "sdsoft.helper@gmail.com",
                    Password = "zgmexqzwnelymvko"

                }

            };

        /// <summary>
        /// Elfelejtett jelszóhoz függvény
        /// </summary>
        /// <param name="user">Elfelejtett felhasználó</param>
        /// <param name="code">Hitelesítései kód</param>
        public void forgotPasswordEmail(User user, int code)
        {



            SmtpClient Client = SmtpClient;

            MailAddress Küldő = new MailAddress("sdsoft.helper@gmail.com");
            MailAddress Fogadó = new MailAddress(user.Email!);
            MailMessage Üzenet = new MailMessage
            {
                From = Küldő,
                Subject = "Elfelejtett jelszó",
                Body = $"Kedes {user.Name}!\nA jelszó visszaállításhoz generált kód: {code}.\nA megváltoztatáshoz kérjük írja be a 'Hitelesítési kód' mezőbe a kódot, majd adja meg új jelszavát.\nTovábbi kérédekkel forduljon az alkalmazás fejlesztőjéhez és üzemeltetőjéhez!\nElérhetőségek: \tgmal: sdsoft.helper@gmail.com\ttelefonszám: +36(30)3074063"
            };
            Üzenet.To.Add(Fogadó);
            Client.SendMailAsync(Üzenet);
        }

        /// <summary>
        /// Sikeres regisztráció
        /// </summary>
        /// <param name="user">Új felhasználó</param>
        public void succesfullSignIn(User user)
        {



            SmtpClient Client = SmtpClient;
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
     
        /// <summary>
        /// Új üzenet értesítés 
        /// </summary>
        /// <param name="user">Felhasználó akinek az új üzenet lett címezve</param>
        public void sendMessage(User user)
        {



            SmtpClient Client = SmtpClient;
            MailAddress Küldő = new MailAddress("sdsoft.helper@gmail.com");
            MailAddress Fogadó = new MailAddress(user.Email!);
            MailMessage Üzenet = new MailMessage
            {
                From = Küldő,
                Subject = "Új olvasatlan üzenet",
                Body = $"Kedes {user.Name}!\nÖnnek egy új üzenete érkezett az SD-SOFT fiókjába!\n\nAmennyiben kérdése van vagy segítségre szorul, forduljon az alkalmazás fejlesztőjéhez és üzemeltetőjéhez!\nElérhetőségek: \tgmal: sdsoft.helper@gmail.com\ttelefonszám: +36(30)3074063"
            };
            Üzenet.To.Add(Fogadó);
            Client.SendMailAsync(Üzenet);
        }
        /// <summary>
        /// Visszajelzés feldolgozásáról értesítés
        /// </summary>
        /// <param name="user">Visszajelzést író felhasználó</param>
        /// <param name="feedback">Visszajelzés</param>
        public void resiveFeedback(User user, Feedback feedback)
        {
            SmtpClient Client = SmtpClient;
            MailAddress Küldő = new MailAddress("sdsoft.helper@gmail.com");
            MailAddress Fogadó = new MailAddress(user.Email!);
            MailMessage Üzenet = new MailMessage
            {
                From = Küldő,
                Subject = "Visszajelzés feldolgozva",
                Body = $"Kedes {user.Name}!\nAz Ön által küldött visszajelzés feldolgozva és lezárva!\n\n Visszajelzése a következő volt:\n{feedback.FeedbackName} - {feedback.FeedbackType}\n\n\"{feedback.FeedbackDescription}\"\n\nKézbesítve: {feedback.FeedbackDate}" +
                $"\n\nTovábbi kérédekkel forduljon az alkalmazás fejlesztőjéhez és üzemeltetőjéhez!\nElérhetőségek: \tgmal: sdsoft.helper@gmail.com\ttelefonszám: +36(30)3074063"
            };
            Üzenet.To.Add(Fogadó);
            Client.SendMailAsync(Üzenet);
        }

        /// <summary>
        /// Új válaszüzenet értesítés
        /// </summary>
        /// <param name="user">A válaszüzenet címjettje</param>
        public void sendAnswerMessage(User user)
        {
            SmtpClient Client = SmtpClient;
            MailAddress Küldő = new MailAddress("sdsoft.helper@gmail.com");
            MailAddress Fogadó = new MailAddress(user.Email!);
            MailMessage Üzenet = new MailMessage
            {
                From = Küldő,
                Subject = "Új válaszüzenet",
                Body = $"Kedes {user.Name}\nÖnnek új válaszüzenete érkezett az SD-SOFT fiókjába!\n\nAmennyiben kérdése van vagy segítségre szorul, forduljon az alkalmazás fejlesztőjéhez és üzemeltetőjéhez!\nElérhetőségek: \tgmal: sdsoft.helper@gmail.com\ttelefonszám: +36(30)3074063"
            };
            Üzenet.To.Add(Fogadó);
            Client.SendMailAsync(Üzenet);
        }
    }

}
