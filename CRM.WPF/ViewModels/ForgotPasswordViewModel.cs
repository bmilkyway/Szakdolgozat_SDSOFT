using CRM.Domain.Models;
using CRM.WPF.Services.EmailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRM.WPF.ViewModels
{
    public class ForgotPasswordViewModel:ViewModelBase
    {

        private User? forgotUser;
        private int authenticationCode;
       
        private int createCode()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }

        public void LoginWindow()
        {
            Window window = new Login();
            window.Show();
        }

        public bool sendNewPassword(string email)
        {
            if(email == "")
            {
                MessageBox.Show("Nincs megadva email cím!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            else
            {
                forgotUser = UserService!.ForgotUser(email).Result;
                if (forgotUser == null)
                {
                    MessageBox.Show("Ezzel az email címmel még nincs regisztrálva!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    authenticationCode = createCode();
                    EmailSender emailSender = new EmailSender();
                    emailSender.forgotPasswordEmail(forgotUser, authenticationCode);
                    MessageBox.Show("A megadott email-címre elküldött, 4 számjegyű hitelesítési kód megadásával tud új jelszót beállítani!", "Hitelesítési kód elküldve!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
            }
           
        }

        public bool checkCode(string code)
        {
            if (code == null)
            {
                MessageBox.Show("Nincs beírva kód!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                try
                {
                    if (Convert.ToInt32(code) == authenticationCode)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("A beírt kód nem egyezik meg a küldött kóddal!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("A kód nem tartalmazhat betűket, csak számokat!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

            }
        }
    
        public bool checkPassword(string pw1, string pw2)
        {
            if(pw1=="" || pw2 == "")
            {
                MessageBox.Show("Nincs minden mező kitöltve!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                if (pw1 == pw2)
                {
                    forgotUser!.Password = pw1;
                    UserService!.Update(forgotUser.Id,forgotUser);
                    MessageBox.Show("Sikeresen megváltoztatta a jelszavát!", "Sikeres jelszóváltoztatás!", MessageBoxButton.OK, MessageBoxImage.Information);

                    return true;
                }
                else
                {
                    MessageBox.Show("A megadott új jelszók nem egyeznek!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;

                }
            }
        }
    }
}
