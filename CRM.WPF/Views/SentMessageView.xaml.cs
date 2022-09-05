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
    /// Interaction logic for SentMessage.xaml
    /// </summary>
    public partial class SentMessageView : UserControl
    {
        private readonly SentMessageViewModel sentMessageViewModel;
        CollectionView filterView;
        public SentMessageView()
        {
            InitializeComponent();
            sentMessageViewModel = new SentMessageViewModel();
            lbMessageList.ItemsSource = sentMessageViewModel.messageList;
            filterView = (CollectionView)CollectionViewSource.GetDefaultView(lbMessageList.ItemsSource);
            filterView!.Filter = CustomFilter;
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
        private void setMessageViewer(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            txtMessageText.Text = sentMessageViewModel.messageList[lbMessageList.SelectedIndex].MessageText;
            txtSubject.Text = sentMessageViewModel.messageList[lbMessageList.SelectedIndex].Subject;
            txtAddress.Text = sentMessageViewModel.UserService!.Get(sentMessageViewModel.messageList[lbMessageList.SelectedIndex].FromUserId).Result.ToString();
     
            }
            catch
            {

            }
        }

        private void setFilterList(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lbMessageList.ItemsSource).Refresh();
        }
    }
}
