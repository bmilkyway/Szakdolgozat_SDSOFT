using CRM.Domain.Models;
using CRM.WPF.Services.EmailSender;
using CRM.WPF.Views;
using System;
using System.Windows;

namespace CRM.WPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {

        private User? activeUser;

        public LoginViewModel() { 
        }

        public void navigationToMain()
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel(activeUser!);
            window.Show();
        }
       public bool loginIsSuccesful(string username, string password)
        {
            try
            {
                activeUser = UserService!.Login(username, password).Result;

                if (activeUser == null)
                {
                    return false;
                }
                else
                {
                    activeUser.IsActive = true;
                    activeUser.LoginDate = System.DateTime.Now;
                    UserService.Update(activeUser.Id, activeUser);

                    return true;

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
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
