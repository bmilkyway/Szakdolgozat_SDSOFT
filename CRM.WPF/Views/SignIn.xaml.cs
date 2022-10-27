using System.Windows;
using System.Windows.Input;

using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        /// <summary>
        /// A view-hoz tartozó viewModel példánya
        /// </summary>
        private SignInViewModel signInViewModel;
        public SignIn()
        {
            InitializeComponent();
            signInViewModel = new SignInViewModel();
        }
        /// <summary>
        /// Regisztráció elkezdését végző függvény, amelynek a belső függvénye hajta végre az új felhasználónak a beszúrását az adatbázisba, majd továbbnavigál minket a fő alkalmazása.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSignIn(object sender, RoutedEventArgs e)
        {
            if (signInViewModel.registrationIsSuccesful(txtUsername.Text, txtPassword.Password, txtEmail.Text, txtName.Text))
            {
                signInViewModel.navigationToMain();
                this.Close();

            }
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
        /// Visszavisz a bejelentkezés oldalára
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSignIn(object sender, RoutedEventArgs e)
        {
            signInViewModel.LoginWindow();
            this.Close();
        }
    }
}
