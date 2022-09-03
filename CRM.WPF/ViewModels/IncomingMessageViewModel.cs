using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WPF.ViewModels
{
    public class IncomingMessageViewModel :ViewModelBase
    {

        public List<Message> messageList { get; set; }
        private readonly IEnumerable<Message> incomingMessages;
        public IncomingMessageViewModel()
        {
            incomingMessages = MessageService!.IncomingMessages(1).Result;
            messageList = incomingMessages.ToList();
           
        }
    }
}
