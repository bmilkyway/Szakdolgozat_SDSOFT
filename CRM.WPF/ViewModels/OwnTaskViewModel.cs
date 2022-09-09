using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.WPF.ViewModels
{
    public class OwnTaskViewModel:ViewModelBase
    {
        public List<Task> ownTasks { get; set; }

        public int closeTaskCount { get; set; }
        public int planedTaskCount { get; set; }
        public int nearDeadline { get; set; }
       
        private readonly IEnumerable<Task> tasks;
        private readonly User activeUser;
        public OwnTaskViewModel()
        {
            activeUser = UserService!.Get(1).Result;
            tasks = TaskService!.OwnTask(activeUser.Id).Result;
            ownTasks = new List<Task>();
            closeTaskCount = 0;
            planedTaskCount = 0;
            nearDeadline = 0;
            foreach (var task in tasks)
            {
                ownTasks!.Add(task);
                if (task.TaskStatusId == 4)
                {
                    closeTaskCount++;
                }
                else if(task.TaskStatusId == 1)
                {
                    planedTaskCount++;
                }
                if (task.DeadLine!.Value.DayOfYear - DateTime.Now.DayOfYear < 10)
                {
                    nearDeadline++;
                }
            }
           
        }
    }
}
