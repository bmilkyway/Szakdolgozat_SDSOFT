using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WPF.ViewModels
{
    public class SentMessageViewModel :ViewModelBase
    {
        public List<Message> messageList { get; set; }
        private readonly IEnumerable<Message> sentMessages;
        public SentMessageViewModel()
        {
            sentMessages = MessageService!.SentMessages(1).Result;
            messageList = sentMessages.ToList();
        }
    }
}
