using CRM.WPF.Services.EmailSender;
using CRM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel loginViewModel;
        public Login()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            
        }
        #region Alkalmazás bezárása
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region mozgatás
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        #endregion

        private void Log_in(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Nem adott meg felhasználónevet!","Hiba!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else if(txtPassword.Password == "")
            {
                MessageBox.Show("Nem adott meg jelszót!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (loginViewModel.loginIsSuccesful(txtUsername.Text, txtPassword.Password))
                {
                    loginViewModel.navigationToMain();
                    this.Close();
                   
                }
                else
                {
                    MessageBox.Show("Hibás a felhasználónév vagy jelszó!", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);

                    
                }
              
               
            }
          
        }

        


        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
        
            loginViewModel.signInWindow();  
            this.Close();
        }

        private void btnForgetPasswd_Click(object sender, RoutedEventArgs e)
        {
            loginViewModel.forgotPasswordWindow();
            this.Close();
        }
    }
}
