using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels.ActualTaskViewModels
{
    public class ActualTaskViewModel : ViewModelBase
    {
        public List<String> categories { get; set; }
        public List<User> users { get; set; }
        public ActualTaskViewModel()
        {
            users = new List<User>();
            categories = new List<String>()
            {
                "Programozás",
                "Tesztelés",
                "Karbantartás"
            };
            users = UserService!.GetAllUser().Result.ToList();

        }
        public bool takeOnTask(Task actualTask, User user, ListBox lbTask)
        {
            if (actualTask.TaskStatusId == 2)
                actualTask.TaskStatusId = 3;

            actualTask.ResponsibleUserId = user.Id;
            actualTask.StartDate = DateTime.Now;
            TaskService!.Update(actualTask.Id, actualTask);
            lbTask.Items.Refresh();
            return true;
        }
        public bool taskClose(Task actualTask, ListBox lbTask)
        {
            try
            {
                if (actualTask.TaskStatusId == 1)
                {
                    actualTask.TaskStatusId = 2;
                    actualTask.ResponsibleUserId = null;
                    TaskService!.Update(actualTask.Id, actualTask);
                    lbTask.Items.Refresh();
                    return true;
                }
                else
                {
                    actualTask.TaskStatusId = 4;
                    actualTask.CloseDate = DateTime.Now;
                    TaskService!.Update(actualTask.Id, actualTask);
                    lbTask.Items.Refresh();
                    return true;
                }
            }
            catch (Exception)
            { return false; }
        }
        public bool taskModify(Task actualTask, ListBox lbTask, DateTime deadline, string taskCategory, string description)
        {
            try
            {
                actualTask.TaskDescription = description;
                actualTask.DeadLine = deadline;
                actualTask.Category = taskCategory;
                if (deadline < DateTime.Now)
                    if (MessageBox.Show("A megadott határidő kisebb a mai napnál, így a feladat lejárt címkét fog kapni! Menti ettől függetlenül a feladatot?", "Lejárt határidős feladat", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        TaskService!.Update(actualTask.Id, actualTask);
                        lbTask.Items.Refresh();
                        return true;
                    }
                    else
                        return false;
                else
                {
                    TaskService!.Update(actualTask.Id, actualTask);
                    lbTask.Items.Refresh();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool taskTakeOn(Task actualTask, ListBox lbTask, User selectedUser)
        {
            if (actualTask.ResponsibleUserId == selectedUser.Id)
            {
                MessageBox.Show("Nem történt változás, a feladat nem kerül átadásra!");
                return false;
            }
            actualTask.ResponsibleUserId = selectedUser.Id;
            TaskService!.Update(actualTask.Id, actualTask);
            lbTask.Items.Refresh();
            return true;
        }

    }
}
