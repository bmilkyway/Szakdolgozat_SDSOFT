
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using CRM.WPF.State.Navigators;
using CRM.WPF.ViewModels;


namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for IncomingMessage.xaml
    /// </summary>
    public partial class IncomingMessageView : UserControl
    {
        private readonly IncomingMessageViewModel incomingMessageViewModel;
        private List<int> filteredMessageListId;
        private readonly MessageViewModel messageViewModel;
        public IncomingMessageView()
        {
            InitializeComponent();
            filteredMessageListId = new List<int>();
            incomingMessageViewModel = new IncomingMessageViewModel();
            messageViewModel = new MessageViewModel();
            for (int i = 0; i < incomingMessageViewModel.messageListTitle.Count; i++)
            {
                lbMessageList.Items.Add(incomingMessageViewModel.messageListTitle[i].ToString());
                filteredMessageListId.Add(i);
            }
        }

        private void setMessageViewer(object sender, SelectionChangedEventArgs e)
        {
            if (lbMessageList.SelectedIndex != -1)
            {
                try
                {
                    txtMessageText.Text = incomingMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].MessageText;
                    txtSubject.Text = incomingMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].Subject;
                    txtAddress.Text = incomingMessageViewModel.UserService!.Get(incomingMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]].ToUserId).Result.ToString();
                    incomingMessageViewModel.readNewMessage(incomingMessageViewModel.messageList[filteredMessageListId[lbMessageList.SelectedIndex]], lbMessageList, txtFilter);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

                    MessageBox.Show("Nem sikerült megnyitni az adott feladatot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SendAnswer(object sender, RoutedEventArgs e)
        {
            messageViewModel.Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.NewMessage);
        }

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
    }
}
