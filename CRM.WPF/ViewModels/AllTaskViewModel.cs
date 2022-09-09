using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WPF.ViewModels
{
    public class AllTaskViewModel:ViewModelBase
    {
        public int planningTaskCount { get; set; }
        public int closedTaskCount { get; set; }
        public int ownTaskCount { get; set; }
        public int nearDeadline { get; set; }
        public int freeTask { get; set; }
        public List<Domain.Models.Task> allTask { get; set; }
        public User activeUser;
        private readonly IEnumerable<Domain.Models.Task> tasks;
        public AllTaskViewModel()
        {
            activeUser = UserService!.Get(1).Result;
            allTask = new List<Domain.Models.Task>();
            tasks = TaskService!.GetAll().Result;
            planningTaskCount = 0;
            closedTaskCount = 0;
            ownTaskCount = 0;
            freeTask = 0;
            nearDeadline = 0;
            foreach (var task in tasks)
            {
                allTask.Add(task);
                if(task.TaskStatusId==4)
                {
                    closedTaskCount++;
                }
                else if (task.TaskStatusId == 2)
                {
                    freeTask++;

                }
                else if(task.TaskStatusId == 1)
                {
                    planningTaskCount++;
                }
                if(task.DeadLine!.Value.DayOfYear - DateTime.Now.DayOfYear < 10)
                {
                    nearDeadline++;
                }
                if (task.ResponsibleUserId == activeUser.Id)
                {
                    ownTaskCount++;
                }
              


            }
        }
    }
}
