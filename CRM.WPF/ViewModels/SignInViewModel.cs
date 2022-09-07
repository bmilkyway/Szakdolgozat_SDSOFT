using CRM.Domain.Models;
using CRM.WPF.Services.EmailSender;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CRM.WPF.ViewModels
{
   
    public class SignInViewModel:ViewModelBase
    {   private User? newUser;
        private  IEnumerable<User>? allUsers;
        public void navigationToMain()
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel(newUser!);
            window.Show();
        }

        public bool registrationIsSuccesful(string username, string password, string email,string name)
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
            else if (username=="")
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
                allUsers = UserService!.GetAll().Result;
                foreach (var user in allUsers)
                {
                    if (user.UserName!.ToLower() == username.ToLower())
                    {
                        MessageBox.Show("Ez a felhasználónév már foglalt!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if(user.Email!.ToLower() == email.ToLower())
                    {
                        MessageBox.Show("Erre az Email-címre már regisztráltak! Kérem adjon meg egy másikat!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    
                }
                newUser = new User
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    UserName = username,
                    RegistrationDate = DateTime.Now,
                    LoginDate = DateTime.Now,
                    IsActive = true,
                    PermissionId = 2,
                };
                UserService.Ceate(newUser);
                EmailSender senderEmail = new EmailSender();
                senderEmail.succesfullSignIn(newUser);
                MessageBox.Show("Sikeres regisztráció!", "Regisztráció", MessageBoxButton.OK);


                return true;

            }
            
           
           
            
        }
        public void LoginWindow()
        {
            Window window = new Login();
            window.Show();
        }
    }
   
}
