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
    /// Interaction logic for IncomingMessage.xaml
    /// </summary>
    public partial class IncomingMessageView : UserControl
    {
        private readonly IncomingMessageViewModel incomingMessageViewModel;
        public IncomingMessageView()
        {
            InitializeComponent();
            incomingMessageViewModel = new IncomingMessageViewModel();
        }

        private void setMessageViewer(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtMessageText.Text = incomingMessageViewModel.messageList[lbMessageList.SelectedIndex].MessageText;
                txtSubject.Text = incomingMessageViewModel.messageList[lbMessageList.SelectedIndex].Subject;
                txtAddress.Text = incomingMessageViewModel.UserService!.Get(incomingMessageViewModel.messageList[lbMessageList.SelectedIndex].ToUserId).Result.ToString();

            }
            catch
            {

            }
        }

        private void SendAnswer(object sender, RoutedEventArgs e)
        {

        }
    }
}
