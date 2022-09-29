using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using CRM.Domain.Models;
using CRM.Domain.Services;

namespace CRM.WPF.ViewModels
{
    public class ActualTaskOpenViewModel : ViewModelBase
    {
        public bool takeOnTask(Task actualTask, User user)
        {
            if (actualTask.TaskStatusId == 2)
                actualTask.TaskStatusId = 3;

            actualTask.ResponsibleUserId = user.Id;
            TaskService!.Update(actualTask.Id, actualTask);
            return true;
        }
        public bool taskClose(Task actualTask)
        {
            if (actualTask.TaskStatusId == 1)
            {
                actualTask.TaskStatusId = 2;
                actualTask.ResponsibleUserId = null;
                TaskService!.Update(actualTask.Id, actualTask);
                return true;
            }
            else
            {
                actualTask.TaskStatusId = 4;
                actualTask.CloseDate = DateTime.Now;
                TaskService!.Update(actualTask.Id, actualTask);

                return true;
            }

        }
    }
   
 }

