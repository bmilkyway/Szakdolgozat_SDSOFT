using System;
using System.Collections.Generic;
using System.Linq;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class SentMessageViewModel : ViewModelBase
    {
        public List<Message> messageList { get; set; }
        private readonly IEnumerable<Message> sentMessages;

        public List<string> messageListTitle { get; set; }
        public SentMessageViewModel()
        {
            sentMessages = MessageService!.SentMessages(currentUser.Id).Result;
            messageList = sentMessages.ToList();
            messageListTitle = new List<string>();
            for (int i = 0; i < messageList.Count; i++)
            {
                if (messageList[i].isRead == true)
                    messageListTitle.Add(String.Format("{0} - {1}", messageList[i].Subject, messageList[i].SendDate));
                else
                    messageListTitle.Add(String.Format("(Olvasatlan) {0} - {1}", messageList[i].Subject, messageList[i].SendDate));
            }

        }
    }
}
