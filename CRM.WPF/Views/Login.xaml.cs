using System.Windows;
using System.Windows.Input;

using CRM.WPF.ViewModels;

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
                MessageBox.Show("Nem adott meg felhasználónevet!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPassword.Password == "")
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
