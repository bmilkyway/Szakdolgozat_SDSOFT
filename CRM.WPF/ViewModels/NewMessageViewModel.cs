
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Media;
using CRM.Domain.Models;
using CRM.WPF.Services.EmailSender;

namespace CRM.WPF.ViewModels
{
    public class NewMessageViewModel :ViewModelBase
    {

        public List<User>? userList { get; set; }
        
        public List<User>? activeUsers { get; }

        private readonly IEnumerable<User> activeUserList;
        private readonly IEnumerable<User> users;
        public NewMessageViewModel()
        {
            activeUserList = UserService!.ActiveUsers().Result;
            users = UserService!.GetAll().Result;
         
            activeUsers = new List<User>();
            userList = new List<User>();
            foreach (var user in users)
            {
                userList.Add(user);
                
            }
            foreach (var user in activeUserList)
            {
                activeUsers!.Add(user);
            }
            
        }
        public void sendMessage(Message message,User user)
        {
            MessageService!.Create(message);
            EmailSender sender = new EmailSender();
            sender.sendMessage(user);
        }
            
      
    }
}
