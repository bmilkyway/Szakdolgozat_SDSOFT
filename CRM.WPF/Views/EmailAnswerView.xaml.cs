using System;

using System.Windows;

using CRM.Domain.Models;
using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for EmailAnswerView.xaml
    /// </summary>
    public partial class EmailAnswerView : Window
    {
        /// <summary>
        /// View-hoz tartozó viewModel
        /// </summary>
        private readonly EmailAnswerViewModel emailAnswerViewModel;

        public User addressUser { get; set; }
        public EmailAnswerView(Message message)
        {
            InitializeComponent();
            emailAnswerViewModel = new EmailAnswerViewModel();
            this.Title = String.Format("{0} - válasz",message.Subject);
            addressUser = emailAnswerViewModel.UserService!.Get(message.FromUserId).Result;
            txtAddress.Text = addressUser.Name;
            txtSubject.Text = String.Format("Re:{0}",message.Subject);
        }
        /// <summary>
        /// Üzenet válaszolása,megzénzi hogy ki van e töltve minden mező, ha igen akkor meghívja a viewModelben létrehozott függvényt, ami az üzenet rögzítését és az értesítés küldését végzi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendAnswer(object sender, RoutedEventArgs e)
        {
            if (txtMessageText.Text != "")
            {
                Message newMessage = new Message
                {
                    isRead = false,
                    FromUserId= emailAnswerViewModel.currentUser.Id,
                    ToUserId = addressUser.Id,
                    Subject =txtSubject.Text,
                    SendDate=DateTime.Now,
                    MessageText=txtMessageText.Text,
                    

                };
                emailAnswerViewModel.SendAnswer(addressUser, newMessage);
                this.Close();
            }
            else
                MessageBox.Show("Nincs kitöltve az üzenet törzse!","Hiba",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
