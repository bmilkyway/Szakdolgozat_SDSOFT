using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class IncomingMessageViewModel : ViewModelBase
    {

        public List<Message> messageList { get; set; }
        private readonly IEnumerable<Message> incomingMessages;
        public List<string> messageListTitle { get; set; }
        public IncomingMessageViewModel()
        {
            incomingMessages = MessageService!.IncomingMessages(currentUser.Id).Result;
            messageList = incomingMessages.ToList();
            messageListTitle = new List<string>();
            for (int i = 0; i < messageList.Count; i++)
            {
                if (messageList[i].isRead == true)
                    messageListTitle.Add(String.Format("{0} - {1}", messageList[i].Subject, messageList[i].SendDate));
                else
                    messageListTitle.Add(String.Format("(Új) {0} - {1}", messageList[i].Subject, messageList[i].SendDate));
            }
        }

        public async void readNewMessage(Message actualMessage, ListBox lbMessages, TextBox txtFilter)
        {
            if (!actualMessage.isRead)
            {
                actualMessage.isRead = true;
                await MessageService!.Update(actualMessage.Id, actualMessage);
                messageList = MessageService!.IncomingMessages(currentUser.Id).Result.ToList();
                lbMessages.Items.Clear();
                for (int i = 0; i < messageList.Count; i++)
                {
                    if (messageList[i].isRead == true)
                        lbMessages.Items.Add(String.Format("{0} - {1}", messageList[i].Subject, messageList[i].SendDate));
                    else
                        lbMessages.Items.Add(String.Format("(Új) {0} - {1}", messageList[i].Subject, messageList[i].SendDate));
                }
            }
        }


    }
}
