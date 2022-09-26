using CRM.Domain.Models;
using CRM.LocalDb;
using CRM.WPF.State.Navigators;

using SQLite;

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
        private SQLiteConnection connection = new SQLiteConnection("currentUserDb.db3");
      
        public IncomingMessageViewModel()
        {
            incomingMessages = MessageService!.IncomingMessages(  UserService!.Get(connection.Get<CurrentUser>(1).userId).Result.Id).Result;
            messageList = incomingMessages.ToList();
            connection.Close();
           
        }

        public void readNewMessage(Message actualMessage)
        {
            if (!actualMessage.isRead)
            {
                actualMessage.isRead = true;
                MessageService!.Update(actualMessage.Id,actualMessage);
                messageList = MessageService!.IncomingMessages(1).Result.ToList();

            }
        }

       
    }
}
