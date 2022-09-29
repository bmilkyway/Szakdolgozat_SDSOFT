using CRM.Domain.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for NewMessage.xaml
    /// </summary>
    public partial class NewMessageView : UserControl
    {
        NewMessageViewModel newMessageViewModel;
        public NewMessageView()
        {
            InitializeComponent();
             newMessageViewModel = new NewMessageViewModel();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            if (cbToUserAddress.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kitöltve a cím!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    newMessageViewModel.sendMessage(new Message
                    {

                        ToUserId =newMessageViewModel.userList![cbToUserAddress.SelectedIndex].Id,
                        FromUserId = newMessageViewModel.currentUser.Id,
                        MessageText = txtMessageText.Text,
                        Subject = txtSubjectText.Text,
                        isRead = false,
                        SendDate = DateTime.Now
                    });
                    MessageBox.Show("Az üzenet el lett küldve!", "Sikeres küldés!", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtMessageText.Text = "";
                    txtSubjectText.Text = "";
                    cbToUserAddress.SelectedIndex = -1;
                }
                catch
                {
                    MessageBox.Show("Nem sikerült elküldeni az üzenetet!", "Sikertelen küldés!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
        }

        private void setAddressInComboBox(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cbToUserAddress.Items.Count; i++)
            {
                if (lbActiveUsers.SelectedItem.ToString() == cbToUserAddress.Items[i].ToString())
                {
                    cbToUserAddress.SelectedIndex = i;
                    cbToUserAddress.SelectedItem = i;

                
                    break;
                }
            }

        }


    }
}
