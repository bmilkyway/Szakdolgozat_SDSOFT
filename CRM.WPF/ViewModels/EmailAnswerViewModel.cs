using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using CRM.Domain.Models;
using CRM.WPF.Services.EmailSender;

namespace CRM.WPF.ViewModels
{
    public class EmailAnswerViewModel:ViewModelBase
    {
        public User actualUser { get; set; }
        public EmailAnswerViewModel()
        {
            actualUser = currentUser;
        }

        /// <summary>
        /// Létrehozza az új üzenetet az adatbázisba, majd küld egy emailt annak a felhasználónak akinek a válaszüzenet van címezve
        /// </summary>
        /// <param name="address"></param>
        /// <param name="message"></param>
        async public void SendAnswer(User address, Message message)
        {
           await MessageService!.Create(message);
            EmailSender sender = new EmailSender();
            sender.sendAnswerMessage(address);
            MessageBox.Show("Sikeresen elküldte válaszát!", "Sikeres küldés", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
