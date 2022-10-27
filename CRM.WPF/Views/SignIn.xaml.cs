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
        private SignInViewModel signInViewModel;
        public SignIn()
        {
            InitializeComponent();
            signInViewModel = new SignInViewModel();
        }

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

        private void CancelSignIn(object sender, RoutedEventArgs e)
        {
            signInViewModel.LoginWindow();
            this.Close();
        }
    }
}
