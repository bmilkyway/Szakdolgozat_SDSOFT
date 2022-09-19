﻿using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WPF.ViewModels
{
    public class AllTaskViewModel:ViewModelBase
    {
       
        public List<Domain.Models.Task> allTask { get;  }
        public List<Domain.Models.Task> showFilteredTask { get; set; }
        public List<Domain.Models.Task> planningTask { get; set; }
        public List<Domain.Models.Task> closedTask { get; set; }
        public List<Domain.Models.Task> ownTask { get; set; }
        public List<Domain.Models.Task> freeTask { get; set; }
        public List<Domain.Models.Task> startedTask { get; set; }
        public List<Domain.Models.Task> expiredTask { get; set; }
        public List<Domain.Models.Task> nearDeadlineTask { get; set; }
        public User activeUser;
        private readonly IEnumerable<Domain.Models.Task> tasks;
        public AllTaskViewModel()
        {
            activeUser = UserService!.Get(1).Result;
            allTask = new List<Domain.Models.Task>();
            planningTask = new List<Domain.Models.Task>();
            closedTask = new List<Domain.Models.Task>();
            ownTask = new List<Domain.Models.Task>();
            freeTask = new List<Domain.Models.Task>();
            startedTask = new List<Domain.Models.Task>();
            expiredTask = new List<Domain.Models.Task>();
            nearDeadlineTask = new List<Domain.Models.Task>();
            showFilteredTask = new List<Domain.Models.Task>();
            tasks = TaskService!.GetAll().Result;
            

            foreach (var task in tasks)
            {
                allTask.Add(task);
                showFilteredTask.Add(task);
                if (task.TaskStatusId == 4)
                {
                    closedTask!.Add(task);
                }
                else if (task.TaskStatusId == 2)
                {
                    freeTask!.Add(task);

                }
                else if (task.TaskStatusId == 3)
                {
                    startedTask!.Add(task);

                }
                else if (task.TaskStatusId == 1)
                {
                    planningTask!.Add(task);
                }
                if (task.DeadLine!.Value.DayOfYear - DateTime.Now.DayOfYear < 10 && task.DeadLine!.Value.DayOfYear - DateTime.Now.DayOfYear >0 && task.TaskStatusId != 4)
                {
                    nearDeadlineTask!.Add(task);
                }
                if (task.DeadLine!.Value.DayOfYear < DateTime.Now.DayOfYear && task.TaskStatusId != 4)
                {
                    expiredTask!.Add(task);
                }

                if (task.ResponsibleUserId == activeUser.Id)
                {
                    ownTask!.Add(task);
                }
              


            }
        }
        public void setShowFilteredTask(bool own, bool planning, bool closed, bool free, bool started, bool expired, bool nearDeadline)
        {
           IEnumerable<Domain.Models.Task> tasks = new List<Domain.Models.Task>();
          
            if (own)
            {
            tasks = ownTask;
            }
            if (planning)
            {
                tasks = tasks.Union(planningTask.ToArray());
            }
            if (closed)
            {
                tasks = tasks.Union(closedTask.ToArray());
            }
            if (free)
            {
                tasks =tasks.Union(freeTask.ToArray());
            }
            if (started)
            {
                tasks = tasks.Union(startedTask.ToArray());
            }
            if (expired)
            {
                tasks = tasks.Union(expiredTask.ToArray());
            }
            if (nearDeadline)
            {
                tasks = tasks.Union(nearDeadlineTask.ToArray());
            }


            showFilteredTask.Clear();
            if (own==false && planning==false && closed==false && free==false && started==false && expired==false && nearDeadline==false)
            {
       
                showFilteredTask = allTask.ToList();
            }
         
            else
            {
               
                showFilteredTask = tasks.ToList();
            }
            
        }
     
    }
}
