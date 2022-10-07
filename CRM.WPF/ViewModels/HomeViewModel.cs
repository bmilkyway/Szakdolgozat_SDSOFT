
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
        public List<Task> showFilteredTask { get; set; }
        public List<Task> activeTaskCount { get; set; }
        public List<Task> closedTaskCount { get; set; }
        public List<Task> plannedTaskCount { get; set; }
        public List<Task> nearTheDeadlineCount { get; set; }
        public List<Task> expiredTaskCount { get; set; }

        public int unReadMessageCount { get; set; }
        public List<Task>? ownTasks { get; set; }


        public  User active_User;
        private readonly IEnumerable<Task> tasks;
        private readonly IEnumerable<Message> messages;
    
        public HomeViewModel()
        {

            active_User = currentUser;
            tasks = TaskService!.OwnTask(active_User.Id).Result;
            messages = MessageService!.GetAll().Result;
            activeTaskCount = new List<Task>();
            closedTaskCount = new List<Task>();
            plannedTaskCount = new List<Task>();
            showFilteredTask = new List<Task>();
            expiredTaskCount = new List<Task>();
            unReadMessageCount = 0;
            nearTheDeadlineCount = new List<Task>();
            ownTasks = new List<Task>();
            foreach (var task in tasks)
            {
                showFilteredTask.Add(task);
                ownTasks.Add(task);
                    switch (task.TaskStatusId)
                    {
                        case 1: 
                            plannedTaskCount.Add(task);
                            break;
                        case 2:
                            break;
                        case 3:
                            activeTaskCount.Add(task);
                            break;
                        case 4:
                            closedTaskCount.Add(task);
                            break;
                    }
                    if(Convert.ToDateTime(task.DeadLine)>DateTime.UtcNow && task.TaskStatusId!=4 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                    {
                        nearTheDeadlineCount.Add(task);
                    }
              else  if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4 )
                {
                    expiredTaskCount.Add(task);
                }

            }
            foreach(var message in messages)
            {
                if(message.ToUserId==active_User.Id && message.isRead == false)
                {
                    unReadMessageCount++;
                }
            }
         


        }

        public void reset() 
        {
            
            showFilteredTask.Clear();
            ownTasks!.Clear();
            plannedTaskCount.Clear();
            activeTaskCount.Clear();
            closedTaskCount.Clear();
            expiredTaskCount.Clear();
            nearTheDeadlineCount.Clear();
            var tasks =TaskService!.OwnTask(active_User.Id).Result;
            foreach (var task in tasks)
            {
                
                switch (task.TaskStatusId)
                {
                    case 1:
                        showFilteredTask.Add(task);
                        ownTasks.Add(task);
                        plannedTaskCount.Add(task);
                        break;
                    case 2:
                        break;
                    case 3:
                        showFilteredTask.Add(task);
                        ownTasks.Add(task);
                        activeTaskCount.Add(task);
                        break;
                    case 4:
                        showFilteredTask.Add(task);
                        ownTasks.Add(task);
                        closedTaskCount.Add(task);
                        break;
                }
                if (Convert.ToDateTime(task.DeadLine) > DateTime.UtcNow && task.TaskStatusId != 4 && task.TaskStatusId != 2 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                {
                  
                    nearTheDeadlineCount.Add(task);
                }
                else if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4 &&task.TaskStatusId!=2)
                {
                   
                    expiredTaskCount.Add(task);
                }

            }

         
        }
        public void setShowFilteredTask(bool planning, bool closed, bool started, bool expired, bool nearDeadline)
        {
            IEnumerable<Domain.Models.Task> tasks = new List<Domain.Models.Task>();


            if (planning)
            {
                tasks = tasks.Union(plannedTaskCount.ToArray());
            }
            if (closed)
            {
                tasks = tasks.Union(closedTaskCount.ToArray());
            }
            if (started)
            {
                tasks = tasks.Union(activeTaskCount.ToArray());
            }

            if (expired)
            {
                tasks = tasks.Union(expiredTaskCount.ToArray());
            }
            if (nearDeadline)
            {
                tasks = tasks.Union(nearTheDeadlineCount.ToArray());
            }


            showFilteredTask.Clear();
            if (planning == false && closed == false && started == false && expired == false && nearDeadline == false)
            {

                showFilteredTask = ownTasks!.ToList();
            }

            else
            {

                showFilteredTask = tasks.ToList();
            }

        }

    } 
    
    
}

