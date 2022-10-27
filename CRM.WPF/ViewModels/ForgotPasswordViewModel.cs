using System;
using System.Windows;

using CRM.Domain.Models;
using CRM.Domain.Services.NewFolder;
using CRM.WPF.Services.EmailSender;

namespace CRM.WPF.ViewModels
{
    public class ForgotPasswordViewModel : ViewModelLoginBase
    {

        private User? forgotUser;
        private int authenticationCode;

        /// <summary>
        /// Létrehoz egy 4 számjegyű kódot, ezzel kell hitelesíteni a felhasználónak magát
        /// </summary>
        /// <returns></returns>
        private int createCode()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }
        /// <summary>
        /// Továbbvisz a bejelentkezés oldalra
        /// </summary>
        public void LoginWindow()
        {
            Window window = new Login();
            window.Show();
        }
        /// <summary>
        /// A függvény elküld egy üzenetet a paraméterben megadott email-címre.
        /// Az email tartalmazza azt a kódot amivel a felhasználó tudja magát azonosítani az új jelszó igényléséhez.
        /// </summary>
        /// <param name="email">Címzett email</param>
        /// <returns></returns>
        public bool sendNewPassword(string email)
        {
            if (email == "")
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
        /// <summary>
        /// A függvény megvizsgálja a beírt hitelesítési kódot, ha egyezik a megadott kód a küldött kóddal, akkor igaz értékkel tér vissza.
        /// </summary>
        /// <param name="code">Hitelesítési kód</param>
        /// <returns></returns>
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
        /// <summary>
        /// Sikeres hitelesítési kód esetén kétszer kell megadni az új jelszót, amelynek egyeznie kell.
        /// Ennek az egyezését végzi a függvény, amely igaz visszatérési érték esetén az új jelszót rögzíti is az adatbázisba
        /// </summary>
        /// <param name="pw1">Jelszó</param>
        /// <param name="pw2">Jelszó megismétlése</param>
        /// <returns></returns>
        public bool checkPassword(string pw1, string pw2)
        {
            if (pw1 == "" || pw2 == "")
            {
                MessageBox.Show("Nincs minden mező kitöltve!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                if (pw1 == pw2)
                {
                    PasswordHasherService passwordHasherService = new PasswordHasherService();
                    string hashedPassword = passwordHasherService.PasswordEncodeing(pw1);
                    forgotUser!.Password = hashedPassword;
                    UserService!.Update(forgotUser.Id, forgotUser);
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
