using System;
using System.Collections.Generic;
using System.Linq;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class OwnTaskViewModel : ViewModelBase
    {
        public List<Task> showFilteredTask { get; set; }
        public List<Task> ownTasks { get; set; }
        public List<Task> closedTaskCount { get; set; }
        public List<Task> startedTaskCount { get; set; }
        public List<Task> plannedTaskCount { get; set; }
        public List<Task> nearDeadline { get; set; }
        public List<Task> expired { get; set; }
        private readonly IEnumerable<Task> tasks;
        public User activeUser;
        public OwnTaskViewModel()
        {
            activeUser = currentUser;
            tasks = TaskService!.OwnTask(activeUser.Id).Result;
            ownTasks = new List<Task>();
            closedTaskCount = new List<Task>();
            plannedTaskCount = new List<Task>();
            nearDeadline = new List<Task>();
            expired = new List<Task>();
            showFilteredTask = new List<Task>();
            startedTaskCount = new List<Task>();
            foreach (var task in tasks)
            {
                showFilteredTask.Add(task);
                ownTasks!.Add(task);
                if (task.TaskStatusId == 4)
                    closedTaskCount.Add(task);
                else if (task.TaskStatusId == 1)
                    plannedTaskCount.Add(task);
                else if (task.TaskStatusId == 3)
                    startedTaskCount.Add(task);
                if (task.DeadLine!.Value.DayOfYear - DateTime.Now.DayOfYear < 10 && task.DeadLine!.Value.DayOfYear - DateTime.Now.DayOfYear > 0 && task.TaskStatusId != 4)
                    nearDeadline.Add(task);
                else if (task.DeadLine!.Value.DayOfYear > DateTime.Now.DayOfYear && task.TaskStatusId != 4)
                    expired.Add(task);
            }


        }
        public void reset()
        {
            showFilteredTask.Clear();
            ownTasks!.Clear();
            plannedTaskCount.Clear();
            startedTaskCount.Clear();
            closedTaskCount.Clear();
            expired.Clear();
            nearDeadline.Clear();
            var tasks = TaskService!.OwnTask(activeUser.Id).Result;
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
                        startedTaskCount.Add(task);
                        break;
                    case 4:
                        showFilteredTask.Add(task);
                        ownTasks.Add(task);
                        closedTaskCount.Add(task);
                        break;
                }
                if (Convert.ToDateTime(task.DeadLine) > DateTime.UtcNow && task.TaskStatusId != 4 && task.TaskStatusId != 2 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                    nearDeadline.Add(task);
                else if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4 && task.TaskStatusId != 2)
                    expired.Add(task);
            }


        }
        public void setShowFilteredTask(bool planning, bool closed, bool started, bool expired, bool nearDeadline)
        {
            IEnumerable<Domain.Models.Task> tasks = new List<Domain.Models.Task>();


            if (planning)
                tasks = tasks.Union(plannedTaskCount.ToArray());
            if (closed)
                tasks = tasks.Union(closedTaskCount.ToArray());
            if (started)
                tasks = tasks.Union(startedTaskCount.ToArray());
            if (expired)
                tasks = tasks.Union(this.expired.ToArray());
            if (nearDeadline)
                tasks = tasks.Union(this.nearDeadline.ToArray());


            showFilteredTask.Clear();
            if (planning == false && closed == false && started == false && expired == false && nearDeadline == false)
                showFilteredTask = ownTasks.ToList();
            else
                showFilteredTask = tasks.ToList();

        }
    }
}
