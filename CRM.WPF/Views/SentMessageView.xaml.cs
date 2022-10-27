using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;
using CRM.WPF.ViewModels;

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
            for (int i = 0; i < sentMessageViewModel.messageListTitle.Count; i++)
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
                User addressUser = sentMessageViewModel.UserService!.Get(sentMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].ToUserId).Result;
                if(addressUser==null || addressUser.PermissionId==5)
                    txtAddress.Text = "Törölt felhasználó";
                else txtAddress.Text = addressUser.Name;
                txtSubject.Text = sentMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].Subject;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

                MessageBox.Show("Nem sikerült megnyitni az adott feladatot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void setFilterList(object sender, TextChangedEventArgs e)
        {
            lbMessageList.Items.Clear();
            filteredMessageListId.Clear();
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                for (int i = 0; i < sentMessageViewModel.messageListTitle.Count; i++)
                    if (sentMessageViewModel.messageListTitle[i].Contains(txtFilter.Text))
                    {
                        lbMessageList.Items.Add(sentMessageViewModel.messageListTitle[i]);
                        filteredMessageListId.Add(i);
                    }
            }
            else
            {
                for (int i = 0; i < sentMessageViewModel.messageListTitle.Count; i++)
                {
                    lbMessageList.Items.Add(sentMessageViewModel.messageListTitle[i].ToString());
                    filteredMessageListId.Add(i);
                }
            }
        }
    }
}
