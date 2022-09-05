using CRM.Domain.Models;
using CRM.WPF.Views;

using System.Windows;

namespace CRM.WPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {

        private User? acticeUser;

        public LoginViewModel() { 
        }

        public void navigationToMain()
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel(acticeUser!);
            window.Show();
        }
       public bool loginIsSuccesful(string username, string password)
        {
            acticeUser = UserService!.Login(username, password).Result;

            if (acticeUser == null)
            {
                return false;     
            }
            else
            { 
                 acticeUser.IsActive = true;
                acticeUser.LoginDate = System.DateTime.Now;
                UserService.Update(acticeUser.Id,acticeUser);
                 return true;
                
            }
        }

        public void signInWindow()
        {
            Window window = new SignIn();
            window.Show();
        }
    }
}
