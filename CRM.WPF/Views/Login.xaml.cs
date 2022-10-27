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

        /// <summary>
        /// A view-hoz tartozó viewModel példánya
        /// </summary>
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


        /// <summary>
        /// Ellenőrzi a beviteli mezőt és hogy található e ilyen felhasználó az adatbázisba. 
        /// A belső meghívott függvényt a view-hoz tartozó viewModel-en van megvalósítva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_in(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
                MessageBox.Show("Nem adott meg felhasználónevet!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (txtPassword.Password == "")
                MessageBox.Show("Nem adott meg jelszót!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (loginViewModel.loginIsSuccesful(txtUsername.Text, txtPassword.Password))
                {
                    loginViewModel.navigationToMain();
                    this.Close();
                }
                else
                    MessageBox.Show("Hibás a felhasználónév vagy jelszó!", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        /// <summary>
        /// Átvisz a regisztrációs oldalra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            loginViewModel.signInWindow();
            this.Close();
        }
        /// <summary>
        /// Átvisz az elfelejtett jelsztó oldalra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForgetPasswd_Click(object sender, RoutedEventArgs e)
        {
            loginViewModel.forgotPasswordWindow();
            this.Close();
        }
    }
}
