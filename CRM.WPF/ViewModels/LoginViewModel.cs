using System;
using System.Windows;

using CRM.Domain.Models;
using CRM.Domain.Services.NewFolder;
using CRM.LocalDb;
using CRM.WPF.Views;

using SQLite;

namespace CRM.WPF.ViewModels
{
    public class LoginViewModel : ViewModelLoginBase
    {
        /// <summary>
        /// Bejelentkezett felhasználó
        /// </summary>
        private User? activeUser;
        /// <summary>
        /// Bejelentkezett felhasználó adatait tartalmazó osztálypéldány,amely mentésre kerül a lokális adatbázisba
        /// </summary>
        private CurrentUser? currentUser;
        public LoginViewModel()
        {
        }
        /// <summary>
        /// Továbbvisz a fő alkalmazásba
        /// </summary>
        public void navigationToMain()
        {
            Window window = new MainWindow(currentUser!.userId);
            window.DataContext = new MainViewModel();


            window.Show();
        }

        /// <summary>
        /// Ellenőrzi az autentikáció érvényességét
        /// </summary>
        /// <param name="username">Felhasználónév</param>
        /// <param name="password">Jelszó</param>
        /// <returns></returns>
        public bool loginIsSuccesful(string username, string password)
        {
            PasswordHasherService passwordHasherService = new PasswordHasherService();
            password = passwordHasherService.PasswordEncodeing(password);
            try
            {
                activeUser = UserService!.Login(username, password).Result;

                if (activeUser is null)
                    return false;

                if (activeUser.PermissionId == 5)
                {
                    MessageBox.Show("A felhasználó függesztve van! Kérem forduljon az alkalmazás üzemeltetőjéhez!", "Függesztett felhasználói fiók!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                activeUser.IsActive = true;
                activeUser.LoginDate = System.DateTime.Now;
                UserService.Update(activeUser.Id, activeUser);

                var db = new SQLiteConnection("currentUserDb.db3");
                db!.CreateTable<CurrentUser>();
                currentUser = new CurrentUser
                {

                    userId = activeUser.Id,
                    userName = activeUser.UserName,
                    name = activeUser.Name,
                    password = activeUser.Password,
                    email = activeUser.Email
                };
                db!.Insert(currentUser);
                db!.Commit();

                db!.Close();



                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }
        /// <summary>
        /// Továbbvisz a regisztrációs oldalra
        /// </summary>
        public void signInWindow()
        {
            Window window = new SignIn();
            window.Show();
        }

        /// <summary>
        /// Továbbvisz az elfelejtett jelszó oldalra
        /// </summary>
        public void forgotPasswordWindow()
        {
            Window window = new ForgotPasswordView();
            window.Show();
        }
    }
}
