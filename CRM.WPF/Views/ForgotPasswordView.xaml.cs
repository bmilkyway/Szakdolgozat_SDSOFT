using System.Windows;
using System.Windows.Input;

using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for ForgotPasswordView.xaml
    /// </summary>
    public partial class ForgotPasswordView : Window
    {  
        /// <summary>
        /// Az éppen aktuális funkciót tartalmazza
        /// </summary>
       private function func;
        /// <summary>
        /// View-hoz tartozó viewModel példánya
        /// </summary>
        private ForgotPasswordViewModel forgotPasswordViewModel;
        public ForgotPasswordView()
        {
            InitializeComponent();
            forgotPasswordViewModel = new ForgotPasswordViewModel();
            func = function.getCode;
        }
        /// <summary>
        /// Elküldi az 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendAutenticationCode(object sender, RoutedEventArgs e)
        {
            switch (func)
            {
                case function.getCode:
                    if (forgotPasswordViewModel.sendNewPassword(txtEmail.Text))
                    {
                        txtCode.Visibility = Visibility.Visible;
                        txtCode.IsEnabled = true;
                        func = function.checkCode;
                        btnSignIn.Content = "Kód ellenőrzése";
                    }
                    break;
                case function.checkCode:
                    if (forgotPasswordViewModel.checkCode(txtCode.Text))
                    {
                        txtNewPassword.Visibility = Visibility.Visible;
                        txtNewPasswordCopy.Visibility = Visibility.Visible;
                        txtNewPassword.IsEnabled = true;
                        txtNewPasswordCopy.IsEnabled = true;
                        func = function.checkPasswords;
                        btnSignIn.Content = "Jelszavak ellenőrzése";
                    }
                    break;
                case function.checkPasswords:
                    if (forgotPasswordViewModel.checkPassword(txtNewPassword.Password, txtNewPasswordCopy.Password))
                    {
                        forgotPasswordViewModel.LoginWindow();
                        this.Close();
                    }
                    break;


            }


        }
        /// <summary>
        /// Visszalép a login oldalhoz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelForgotPassword(object sender, RoutedEventArgs e)
        {
            forgotPasswordViewModel.LoginWindow();
            this.Close();
        }
        #region mozgatás
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        #endregion
        #region Alkalmazás bezárása
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
    /// <summary>
    /// A funkciók enum listája 
    /// </summary>
    enum function
    {
        getCode,
        checkCode,
        checkPasswords,

    }
}
