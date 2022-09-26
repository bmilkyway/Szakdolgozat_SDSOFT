using CRM.Domain.Models;
using CRM.LocalDb;

using SQLite;

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
        private SQLiteConnection connection = new SQLiteConnection("currentUserDb.db3");
        public SentMessageViewModel()
        {
            sentMessages = MessageService!.SentMessages(UserService!.Get(connection.Get<CurrentUser>(1).userId).Result.Id).Result;
            messageList = sentMessages.ToList();
            connection.Close();
        }
    }
}
