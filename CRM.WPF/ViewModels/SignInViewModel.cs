using System;
using System.Collections.Generic;
using System.Windows;

using CRM.Domain.Models;
using CRM.Domain.Services.NewFolder;
using CRM.LocalDb;
using CRM.WPF.Services.EmailSender;

using SQLite;

namespace CRM.WPF.ViewModels
{

    public class SignInViewModel : ViewModelLoginBase
    {
        private User? newUser;
        private CurrentUser? currentUser;
        private IEnumerable<User>? allUsers;
        

        /// <summary>
        /// Továbbvisz a fő alkalmazásba
        /// </summary>
        public void navigationToMain()
        {
            Window window = new MainWindow(newUser!.Id);
            window.DataContext = new MainViewModel();
            window.Show();
        }
        /// <summary>
        /// Vizsgálja a regisztráció sikerességét a paraméterek alapján.
        /// Sikeres vizsgálat után a paraméterek alapján létrehoz egy új User objektumot, majd hozzáadja az adatbázishoz és beléptet a fő alkalmazásba
        /// </summary>
        /// <param name="username">Felhasználónév</param>
        /// <param name="password">Jelszó</param>
        /// <param name="email">Email cím</param>
        /// <param name="name">Felhasználónév</param>
        /// <returns>[true]-> sikeres, [false]-> sikertelen</returns>
        public bool registrationIsSuccesful(string username, string password, string email, string name)
        {
            if (name == "")
            {
                MessageBox.Show("Nincs kitöltve a Név mező!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (email == "")
            {
                MessageBox.Show("Nincs kitöltve a Email mező!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (username == "")
            {
                MessageBox.Show("Nincs kitöltve a Felhasználónév mező!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (password == "")
            {
                MessageBox.Show("Nincs kitöltve a Jelszó mező!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else
            {
                allUsers = UserService!.GetAllUser().Result;
                foreach (var user in allUsers)
                {
                    if (user.UserName!.ToLower() == username.ToLower())
                    {
                        MessageBox.Show("Ez a felhasználónév már foglalt!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (user.Email!.ToLower() == email.ToLower())
                    {
                        MessageBox.Show("Erre az Email-címre már regisztráltak! Kérem adjon meg egy másikat!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                }
                PasswordHasherService passwordHasherService = new PasswordHasherService();
                string hashedPassword = passwordHasherService.PasswordEncodeing(password);
                newUser = new User
                {
                    Name = name,
                    Email = email,
                    Password = hashedPassword,
                    UserName = username,
                    RegistrationDate = DateTime.Now,
                    LoginDate = DateTime.Now,
                    IsActive = true,
                    PermissionId = 3,
                };
                newUser = UserService.Create(newUser).Result;
                EmailSender senderEmail = new EmailSender();
                senderEmail.succesfullSignIn(newUser);

                var db = new SQLiteConnection("currentUserDb.db3");
                db!.CreateTable<CurrentUser>();
                currentUser = new CurrentUser
                {
                    userId = newUser.Id,
                    userName = newUser.UserName,
                    name = newUser.Name,
                    password = newUser.Password,
                    email = newUser.Email
                };
                db!.Insert(currentUser);
                db!.Commit();

                db!.Close();


                MessageBox.Show("Sikeres regisztráció!", "Regisztráció", MessageBoxButton.OK);


                return true;

            }




        }
       
        
        /// <summary>
        /// Visszavisz a bejelenzketés oldalra
        /// </summary>
        public void LoginWindow()
        {
            Window window = new Login();
            window.Show();
        }
    }

}
