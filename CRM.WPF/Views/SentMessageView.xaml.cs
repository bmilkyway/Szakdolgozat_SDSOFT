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
     
        private List<int> filteredMessageListId;
        public SentMessageView()
        {
            InitializeComponent();
            filteredMessageListId = new List<int>();
            sentMessageViewModel = new SentMessageViewModel();
            for(int i=0;i<sentMessageViewModel.messageListTitle.Count;i++)
            { 
                lbMessageList.Items.Add(sentMessageViewModel.messageListTitle[i].ToString());
                filteredMessageListId.Add(i);
            }
        }
     
        private void setMessageViewer(object sender, SelectionChangedEventArgs e)
        {
            try
            {
           txtMessageText.Text = sentMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].MessageText;
            txtSubject.Text = sentMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].Subject;
            txtAddress.Text = sentMessageViewModel.UserService!.Get(sentMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].FromUserId).Result.ToString();
            }
            catch
            {

            }
        }

        private void setFilterList(object sender, TextChangedEventArgs e)
        {
            lbMessageList.Items.Clear();
            filteredMessageListId.Clear();
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                for (int i=0;i<sentMessageViewModel.messageListTitle.Count;i++)
                    if (sentMessageViewModel.messageListTitle[i].Contains(txtFilter.Text))
                    {
                        lbMessageList.Items.Add(sentMessageViewModel.messageListTitle[i]);
                        filteredMessageListId.Add(i);
                    }
            }
            else
            {
                for (int i=0;i<sentMessageViewModel.messageListTitle.Count;i++)
                {
                    lbMessageList.Items.Add(sentMessageViewModel.messageListTitle[i].ToString());
                    filteredMessageListId.Add(i);
                }
            }
        }
    }
}
