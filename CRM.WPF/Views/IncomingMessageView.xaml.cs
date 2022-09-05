
using CRM.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for IncomingMessage.xaml
    /// </summary>
    public partial class IncomingMessageView : UserControl
    {
        private readonly IncomingMessageViewModel incomingMessageViewModel;
        CollectionView filterView;
        public IncomingMessageView()
        {
            InitializeComponent();
            incomingMessageViewModel = new IncomingMessageViewModel();
            lbMessageList.ItemsSource = incomingMessageViewModel.messageList;
            filterView = (CollectionView)CollectionViewSource.GetDefaultView(lbMessageList.ItemsSource);
            filterView!.Filter = CustomFilter;
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
        private bool CustomFilter(object obj)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
            {
                return (obj.ToString()!.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }
        private void filterList(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lbMessageList.ItemsSource).Refresh();
        }
    }
}
