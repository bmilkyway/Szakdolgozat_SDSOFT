﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Media;
using CRM.Domain.Models;
using SQLite;
using CRM.LocalDb;

namespace CRM.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public int activeTaskCount { get; set; }
        public int closedTaskCount { get; set; }
        public int plannedTaskCount { get; set; }
        public int nearTheDeadlineCount { get; set; }
    
        public int unReadMessageCount { get; set; }
        public List<Task>? ownTasks { get; set; }


        public  User active_User;
        private readonly IEnumerable<Task> tasks;
        private readonly IEnumerable<Message> messages;
        private SQLiteConnection connection = new SQLiteConnection("currentUserDb.db3");
       
        public HomeViewModel()
        {
            
            active_User =  UserService!.Get(connection.Get<CurrentUser>(1).userId).Result;
            tasks = TaskService!.OwnTask(active_User.Id).Result;
            messages = MessageService!.GetAll().Result;
            activeTaskCount = 0;
            closedTaskCount = 0;
            plannedTaskCount = 0;
            unReadMessageCount = 0;
            nearTheDeadlineCount = 0;
            ownTasks = new List<Task>();
            foreach (var task in tasks)
            {
                ownTasks.Add(task);
                    switch (task.TaskStatusId)
                    {
                        case 1: 
                            plannedTaskCount++;
                            break;
                        case 2:
                            break;
                        case 3:
                            activeTaskCount++;
                            break;
                        case 4:
                            closedTaskCount++;
                            break;
                    }
                    if(Convert.ToDateTime(task.DeadLine)>DateTime.UtcNow && task.TaskStatusId!=4 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                    {
                        nearTheDeadlineCount++;
                    }
                
            }
            foreach(var message in messages)
            {
                if(message.ToUserId==active_User.Id && message.isRead == false)
                {
                    unReadMessageCount++;
                }
            }
            connection.Close();


        }
        
    } 
    
    
}

