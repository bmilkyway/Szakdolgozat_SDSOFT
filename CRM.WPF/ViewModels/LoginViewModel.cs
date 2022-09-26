using System;
using System.Windows;

using CRM.Domain.Models;
using CRM.LocalDb;
using CRM.WPF.Views;

using SQLite;

namespace CRM.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private User? activeUser;
        private CurrentUser? currentUser;
        public LoginViewModel()
        {
        }

        public void navigationToMain()
        {
            Window window = new MainWindow(currentUser!.userId);
            window.DataContext = new MainViewModel();
            window.Show();
        }
        public bool loginIsSuccesful(string username, string password)
        {
            try
            {
                activeUser = UserService!.Login(username, password).Result;

                if (activeUser is null)
                    return false;


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

        public void signInWindow()
        {
            Window window = new SignIn();
            window.Show();
        }
        public void forgotPasswordWindow()
        {
            Window window = new ForgotPasswordView();
            window.Show();
        }
    }
}
