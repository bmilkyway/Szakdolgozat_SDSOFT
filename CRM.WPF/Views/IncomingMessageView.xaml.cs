
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;
using CRM.WPF.ViewModels;


namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for IncomingMessage.xaml
    /// </summary>
    public partial class IncomingMessageView : UserControl
    {
        /// <summary>
        /// View-hoz tartozó view model példánya
        /// </summary>
        private readonly IncomingMessageViewModel incomingMessageViewModel;
        private List<int> filteredMessageListId;
        private Message? selectedMessage;
        public IncomingMessageView()
        {
            InitializeComponent();
            filteredMessageListId = new List<int>();
            incomingMessageViewModel = new IncomingMessageViewModel();
          
            for (int i = 0; i < incomingMessageViewModel.messageListTitle.Count; i++)
            {
                lbMessageList.Items.Add(incomingMessageViewModel.messageListTitle[i].ToString());
                filteredMessageListId.Add(i);
            }
        }
        /// <summary>
        /// Megnyitja az üzenet részletes nézetét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setMessageViewer(object sender, SelectionChangedEventArgs e)
        {
            if (lbMessageList.SelectedIndex != -1)
            {

                try
                {
                    selectedMessage = incomingMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]];
                    txtMessageText.Text = selectedMessage.MessageText;
                    txtSubject.Text = selectedMessage.Subject;
                    User senderUser = incomingMessageViewModel.UserService!.Get(selectedMessage.FromUserId).Result;

                    if (senderUser == null || senderUser.PermissionId == 5)
                    {
                        txtAddress.Text = "Törölt felhasználó";
                        btnSendAnswer.IsEnabled = false;
                    }
                    else
                    {
                        txtAddress.Text = senderUser.Name;
                        btnSendAnswer.IsEnabled = true;
                    }
                    incomingMessageViewModel.readNewMessage(selectedMessage, lbMessageList, txtFilter);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

                    MessageBox.Show("Nem sikerült megnyitni az adott feladatot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Szűri a beérkező listát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterList(object sender, TextChangedEventArgs e)
        {
            lbMessageList.Items.Clear();
            filteredMessageListId.Clear();
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                for (int i = 0; i < incomingMessageViewModel.messageListTitle.Count; i++)
                    if (incomingMessageViewModel.messageListTitle[i].Contains(txtFilter.Text))
                    {
                        lbMessageList.Items.Add(incomingMessageViewModel.messageListTitle[i]);
                        filteredMessageListId.Add(i);
                    }
            }
            else
            {
                for (int i = 0; i < incomingMessageViewModel.messageListTitle.Count; i++)
                {
                    lbMessageList.Items.Add(incomingMessageViewModel.messageListTitle[i].ToString());
                    filteredMessageListId.Add(i);
                }
            }
        }
        /// <summary>
        /// Válaszablak megnyitása, betölti a megnyitott üzenet tartalmát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMessage != null)
            {
                Window answerView = new EmailAnswerView(selectedMessage);
                answerView.ShowDialog();
            }
        }
    }
}
