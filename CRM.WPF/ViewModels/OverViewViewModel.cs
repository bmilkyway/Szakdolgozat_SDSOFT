
using System;
using System.Collections.Generic;
using System.Windows.Media;

using CRM.Domain.Models;
using CRM.LocalDb;

using SQLite;

using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;
using static CRM.WPF.ChartModels.chartModels;

namespace CRM.WPF.ViewModels
{
    public class OverViewViewModel : ViewModelBase
    {
        private List<Task> ownActiveTaskCount { get; set; }
        private List<Task> ownClosedTaskCount { get; set; }
        private List<Task> ownPlannedTaskCount { get; set; }
        private List<Task> ownNearTheDeadlineCount { get; set; }
        private List<Task> activeTaskCount { get; set; }
        private List<Task> closedTaskCount { get; set; }
        private List<Task> freeTaskCount { get; set; }
        private List<Task> expiredTask { get; set; }
        private List<Task> plannedTaskCount { get; set; }
        private List<Task> nearTheDeadlineCount { get; set; }
        public ColumnDiagramm createdAndClosedTasks { get; set; }
        public ColumnDiagramm nearDeadlineTaskTypeSummary { get; set; }
        public ColumnDiagramm ownActicitates { get; set; }
        public PieChartDiagramm ownTasksChart { get; set; }
        public PieChartDiagramm allTasksChart { get; set; }
        public PieChartDiagramm acticeUsers { get; set; }
        public PieChartDiagramm deadlineForTasksChart { get; set; }
        public PieChartDiagramm taskCategories { get; set; }

        private List<Task>? ownTasks { get; set; }
        private List<Task>? allTasks { get; set; }
        private User active_User;
        private readonly IEnumerable<Task> tasks;
        private int createdTaskToday { get; set; }
        private int closedTaskToday { get; set; }
        private int createdTaskOneWeek { get; set; }
        private int createdTaskOneMonth { get; set; }
        private int closedTaskOneMonth { get; set; }
        private int closedTaskOneWeek { get; set; }
        private int programingCategory { get; set; }
        private int testingCategory { get; set; }
        private int maintenanceCategory { get; set; }
        private int farToDeadline { get; set; }
        public IEnumerable<User> activeUsersList;
        public IEnumerable<User> allUsersList;
        private int inactiveUsersCount { get; set; }
        public OverViewViewModel()
        {
            active_User = currentUser;
            tasks = TaskService!.GetAll().Result;
            activeUsersList = UserService!.ActiveUsers().Result;
            allUsersList = UserService!.GetAll().Result;
            ownActiveTaskCount = new List<Task>();
            ownClosedTaskCount = new List<Task>();
            ownPlannedTaskCount = new List<Task>();
            ownNearTheDeadlineCount = new List<Task>();
            freeTaskCount = new List<Task>();
            plannedTaskCount = new List<Task>();
            closedTaskCount = new List<Task>();
            activeTaskCount = new List<Task>();
            expiredTask = new List<Task>();
            nearTheDeadlineCount = new List<Task>();
            createdTaskOneWeek = 0;
            createdTaskToday = 0;
            closedTaskOneWeek = 0;
            closedTaskOneMonth = 0;
            createdTaskOneMonth = 0;
            closedTaskToday = 0;
            farToDeadline = 0;
            programingCategory = 0;
            testingCategory = 0;
            maintenanceCategory = 0;
            inactiveUsersCount = allUsersList.Count()-activeUsersList.Count();
            ownTasks = new List<Task>();
            allTasks = new List<Task>();
            createdAndClosedTasks = new ColumnDiagramm();
            nearDeadlineTaskTypeSummary = new ColumnDiagramm();
            ownActicitates = new ColumnDiagramm();
            allTasksChart = new PieChartDiagramm();
            ownTasksChart = new PieChartDiagramm();
            deadlineForTasksChart = new PieChartDiagramm();
            taskCategories = new PieChartDiagramm();
            acticeUsers = new PieChartDiagramm();
            foreach (var task in tasks)
            {
                allTasks!.Add(task);
                switch (task.Category)
                {
                    case "Programozás":
                        programingCategory++;
                        break;
                    case "Tesztelés":
                        testingCategory++;
                        break;
                    case "Karbantartás":
                        maintenanceCategory++;
                        break;
                }
                if (task.ResponsibleUserId == active_User.Id)
                {
                    ownTasks.Add(task);
                    switch (task.TaskStatusId)
                    {
                        case 1:
                            ownPlannedTaskCount.Add(task);
                            plannedTaskCount.Add(task);
                            break;
                        case 2:
                            freeTaskCount.Add(task);

                            break;
                        case 3:
                            ownActiveTaskCount.Add(task);
                            activeTaskCount.Add(task);
                            break;
                        case 4:

                            ownClosedTaskCount.Add(task);
                            closedTaskCount.Add(task);
                            break;
                    }
                    if (Convert.ToDateTime(task.DeadLine) > DateTime.UtcNow && task.TaskStatusId != 4 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                    {
                        ownNearTheDeadlineCount.Add(task);
                        nearTheDeadlineCount.Add(task);

                    }
                    else if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4)
                        expiredTask.Add(task);
                }
                else
                {
                    switch (task.TaskStatusId)
                    {
                        case 1:
                            plannedTaskCount.Add(task);
                            break;
                        case 2:
                            freeTaskCount.Add(task);
                            break;
                        case 3:
                            activeTaskCount.Add(task);
                            break;
                        case 4:
                            closedTaskCount.Add(task);
                            break;
                    }
                    if (Convert.ToDateTime(task.DeadLine) > DateTime.UtcNow && task.TaskStatusId != 4 && Convert.ToDateTime(task.DeadLine).DayOfYear - DateTime.Now.DayOfYear < 10)
                        nearTheDeadlineCount.Add(task);
                    else if (Convert.ToDateTime(task.DeadLine) < DateTime.UtcNow && task.TaskStatusId != 4)
                        expiredTask.Add(task);
                }
                if (task.CreateDate.Date.DayOfYear == DateTime.Now.Date.DayOfYear && DateTime.Now.Year == task.CreateDate.Year)
                {
                    createdTaskToday++;
                    createdTaskOneMonth++;
                    createdTaskOneWeek++;
                }
                else if (DateTime.Now.DayOfYear - task.CreateDate.DayOfYear <= 7 && DateTime.Now.Year == task.CreateDate.Year)
                {
                    createdTaskOneMonth++;
                    createdTaskOneWeek++;
                }
                else if (DateTime.Now.DayOfYear - task.CreateDate.DayOfYear <= 30 && DateTime.Now.Year == task.CreateDate.Year)
                    createdTaskOneMonth++;
                if (task.CloseDate != null)
                {
                    if (task.CloseDate!.Value.DayOfYear == DateTime.Now.DayOfYear && DateTime.Now.Year == task.CloseDate.Value.Year)
                    {
                        closedTaskToday++;
                        closedTaskOneMonth++;
                        closedTaskOneWeek++;
                    }
                    else if (DateTime.Now.DayOfYear - task.CloseDate!.Value.DayOfYear <= 7 && DateTime.Now.Year == task.CloseDate.Value.Year)
                    {
                        closedTaskOneMonth++;
                        closedTaskOneWeek++;
                    }
                    else if (DateTime.Now.DayOfYear - task.CloseDate!.Value.DayOfYear <= 30 && DateTime.Now.Year == task.CloseDate.Value.Year) 
                        closedTaskOneMonth++;
                }
            }
            farToDeadline = plannedTaskCount.Count + freeTaskCount.Count + activeTaskCount.Count - nearTheDeadlineCount.Count - expiredTask.Count;

            #region Saját feladatok kördiagram
            ownTasksChart.SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title="Elkezdett",
                    Values=new ChartValues<int>{ ownActiveTaskCount.Count }
                },
                new PieSeries
                {
                    Title="Befejezett",

                    Values=new ChartValues<int>{ ownClosedTaskCount.Count }
                },
                new PieSeries
                {

                    Title="Tervezés alatt",
                    Values=new ChartValues<int>{ ownPlannedTaskCount.Count }
                }
            };
            #endregion

            #region Minden feladat kördiagram
            allTasksChart.SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Elkezdett feladatok:",
                    Values=new ChartValues<int>{ activeTaskCount.Count }
                },
                new PieSeries
                {
                    Title = "Lezárt feladatok:",
                    Values=new ChartValues<int>{ closedTaskCount.Count }
                },
                 new PieSeries
                {
                    Title = "Szabad feladatok:",
                    Values=new ChartValues<int>{ freeTaskCount.Count }
                },
                new PieSeries
                {

                    Title = "Tervezés alatti feladatok:",
                    Values=new ChartValues<int>{ plannedTaskCount.Count }
                }
            };
            #endregion

            #region Határidő kördiagram
            deadlineForTasksChart.SeriesCollection = new SeriesCollection
            {

                  new PieSeries
                  {
                    Values=new ChartValues<int>{ nearTheDeadlineCount.Count},
                    Title="10 napon belül lejár"
                  },
                  new PieSeries
                  {
                    Values=new ChartValues<int>{ expiredTask.Count },
                    Title="Lejárt",
                  },
                  new PieSeries
                  {
                    Values=new ChartValues<int>{ farToDeadline
                    },
                    Title = "Távoli határidő"
                  },
            };
            #endregion

            #region Feladatok lezárt és létrehozott elemzése
            createdAndClosedTasks.SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Létrekozva",
                    Values = new ChartValues<int> { createdTaskToday, createdTaskOneWeek ,createdTaskOneMonth}
                }
            };
            createdAndClosedTasks.SeriesCollection.Add(new ColumnSeries
            {
                Title = "Lezárva",
                Values = new ChartValues<int> { closedTaskToday, closedTaskOneWeek, closedTaskOneMonth }
            });
            createdAndClosedTasks.Labels = new[] { "Ma", "7 napja", "30 napja" };
            createdAndClosedTasks.Formatter = value => value.ToString("N0");
            #endregion


            #region Saját tevékenységek
            ownActicitates.SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Feladatok elkezdése",
                    Values=new ChartValues<int>{ 10, 10,12,30 }
                },
                 new ColumnSeries
                {
                    Title="Feladatok lezárása",
                     Values=new ChartValues<int>{ 30, 4,18,36 }
                },
                  new ColumnSeries
                {
                    Title="Feladatok létrehozása",
                     Values=new ChartValues<int>{ 20, 21,10,30 }
                },
            };
            ownActicitates.Labels = new[] { "Ma", "7 napja", "30 napja", "elmúlt időbe" };
            ownActicitates.Formatter = value => value.ToString("N0");
            #endregion

            #region Határidős feladatok 
            nearDeadlineTaskTypeSummary.SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Tervezés alatt",
                    Values = new ChartValues<int> { plannedTaskCount.Count()}
                }
            };
            nearDeadlineTaskTypeSummary.SeriesCollection.Add(new ColumnSeries
            {
                Title = "Szabad",
                Values = new ChartValues<int> { freeTaskCount.Count() }
            });
            nearDeadlineTaskTypeSummary.SeriesCollection.Add(new ColumnSeries
            {
                Title = "Elkezdve",
                Values = new ChartValues<int> { activeTaskCount.Count() }
            });
            nearDeadlineTaskTypeSummary.Labels = new[] { "Közel", "Lejárt" };
            nearDeadlineTaskTypeSummary.Formatter = value => value.ToString("N0");
            #endregion

            #region Aktív felhasználók
            acticeUsers.SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title="Aktív felhasználók",
                    Values = new ChartValues<int> { activeUsersList.ToArray().Length }
                },
                new PieSeries
                {
                    Title="Inaktív felhasználók",
                    Values = new ChartValues<int> { inactiveUsersCount }
                },
            };
            #endregion
            #region Feladat kategóriák 
            taskCategories.SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title="Tesztelés",
                    Values = new ChartValues<int> { testingCategory }
                },
                new PieSeries
                {
                    Title="Programozás",
                    Values = new ChartValues<int> { programingCategory }
                },
                 new PieSeries
                {
                    Title="Karbantartás",
                    Values = new ChartValues<int> { maintenanceCategory }
                },
            };
            #endregion
        }
    }

  
  
}
