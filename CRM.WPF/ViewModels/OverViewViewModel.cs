
using System;
using System.Collections.Generic;
using System.Windows.Media;

using CRM.Domain.Models;
using CRM.LocalDb;

using SQLite;

namespace CRM.WPF.ViewModels
{
    public class OverViewViewModel:ViewModelBase
    {
        public int ownActiveTaskCount { get; set; }
        public int ownClosedTaskCount { get; set; }
        public int ownPlannedTaskCount { get; set; }
        public int ownNearTheDeadlineCount { get; set; }
        public int activeTaskCount { get; set; }
        public int closedTaskCount { get; set; }
        public int freeTaskCount { get; set; }

        public int expiredTask { get; set; }
        public int plannedTaskCount { get; set; }
        public int nearTheDeadlineCount { get; set; }


        public List<Task>? ownTasks { get; set; }
        public List<Task>? allTasks { get; set; }
        public List<Category> OwnTaskCategories { get; set; }
        public List<Category> AllTaskCategories { get; set; }
        public List<Category> DeadlineTaskCategories { get; set; }

        public User active_User;
        private readonly IEnumerable<Task> tasks;
        public  OverViewViewModel ()
        {
            active_User = currentUser;
            tasks = TaskService!.GetAll().Result;
           
            ownActiveTaskCount = 0;
            ownClosedTaskCount = 0;
            ownPlannedTaskCount = 0;
            ownNearTheDeadlineCount = 0;
            ownTasks = new List<Task>();
            allTasks = new List<Task>();
            OwnTaskCategories = new List<Category>();
            AllTaskCategories = new List<Category>();
            DeadlineTaskCategories = new List<Category>();
            foreach (var task in tasks)
            {
                allTasks!.Add(task);
                if (task.ResponsibleUserId == active_User.Id)
                {
                    ownTasks.Add(task);
                    switch (task.TaskStatusId)
                    {
                        case 1:
                            ownPlannedTaskCount++;
                            plannedTaskCount++;
                            break;
                        case 2:
                            freeTaskCount++;
                    
                            break;
                        case 3:
                            ownActiveTaskCount++;
                            activeTaskCount++;
                            break;
                        case 4:
                            ownClosedTaskCount++;
                            closedTaskCount++;
                            break;
                    }
                    if (Convert.ToDateTime(task.DeadLine) > DateTime.UtcNow && task.TaskStatusId != 4 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                    {
                        ownNearTheDeadlineCount++;
                        nearTheDeadlineCount++;

                    }
                    else if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4)
                    {
                        expiredTask++;
                    }
                }
                else
                {
                    switch (task.TaskStatusId)
                    {
                        case 1:
                          
                            plannedTaskCount++;
                            break;
                        case 2:
                            freeTaskCount++;
                            break;
                        case 3:
                           
                            activeTaskCount++;
                            break;
                        case 4:
                          
                            closedTaskCount++;
                            break;
                    }
                    if (Convert.ToDateTime(task.DeadLine) > DateTime.UtcNow && task.TaskStatusId != 4 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                    {
                       
                        nearTheDeadlineCount++;
                    }
                    else if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4 )
                    {
                        expiredTask++;
                    }

                }


            }
            DeadlineTaskCategories = new List<Category>()
            {
                #region Kördiagramm részei
                
                new Category
                {
                    Title = "Lejárt:",
                    Percentage = expiredTask,
                    ColorBrush = Brushes.Red,
                },

                 new Category
                {
                    Title = "10 napon belül lejár:",
                    Percentage = nearTheDeadlineCount,
                    ColorBrush = Brushes.DarkOrange,
                },
                   new Category
                {
                    Title = "Távoli határidő:",
                    Percentage = plannedTaskCount+freeTaskCount+activeTaskCount-nearTheDeadlineCount-expiredTask,
                    ColorBrush = Brushes.Green,
                },
             

                #endregion

            };
            AllTaskCategories = new List<Category>()
            {
                #region Kördiagramm részei
                
                new Category
                {
                    Title = "Tervezés alatti feladatok:",
                    Percentage = plannedTaskCount,
                    ColorBrush = Brushes.Yellow,
                },
              
                 new Category
                {
                    Title = "Szabad feladatok:",
                    Percentage = freeTaskCount,
                    ColorBrush = Brushes.White,
                },
                   new Category
                {
                    Title = "Elkezdett feladatok:",
                    Percentage = activeTaskCount,
                    ColorBrush = Brushes.Green,
                },
                new Category
                {
                    Title = "Lezárt feladatok:",
                    Percentage = closedTaskCount,
                    ColorBrush = Brushes.Gray,
                },

                #endregion

            };
            OwnTaskCategories = new List<Category>()
            {
                #region Kördiagramm részei
                new Category
                {
                    Title = "Elkezdett feladatok:",
                    Percentage = ownActiveTaskCount,
                    ColorBrush = Brushes.Green,
                },
                 new Category
                {
                    Title = "Tervezés alatti feladatok:",
                    Percentage = ownPlannedTaskCount,
                    ColorBrush = Brushes.Yellow,
                },
                new Category
                {
                    Title = "Lezárt feladatok:",
                    Percentage = ownClosedTaskCount,
                    ColorBrush = Brushes.Gray,
                },

               
                #endregion

            };
        }
    }
    public class Category
    {
        public float Percentage { get; set; }
        public string? Title { get; set; }
        public Brush? ColorBrush { get; set; }
    }
}
