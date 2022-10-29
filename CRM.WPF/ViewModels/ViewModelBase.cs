using System.Collections.Generic;

using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;
using CRM.LocalDb;

using SQLite;

namespace CRM.WPF.ViewModels
{
    public class ViewModelBase
    {
        public IDataService<User>? UserService;
        public IDataService<Task>? TaskService;
        public IDataService<Message>? MessageService;
        public IDataService<Status>? StatusService;
        public IDataService<Feedback>? FeedbackService;
        private Task? actualTask;
        private SQLiteConnection connection = new SQLiteConnection("currentUserDb.db3");
        public User currentUser;

        public ViewModelBase()
        {
            UserService = new GenericDataService<User>(new CRM_DbContextFactory());
            TaskService = new GenericDataService<Task>(new CRM_DbContextFactory());
            MessageService = new GenericDataService<Message>(new CRM_DbContextFactory());
            StatusService = new GenericDataService<Status>(new CRM_DbContextFactory());
            FeedbackService = new GenericDataService<Feedback>(new CRM_DbContextFactory());
            currentUser = UserService!.Get(connection.Get<CurrentUser>(1).userId).Result;
            connection.Close();
        }
        public void setActualTask(Task task)
        {
            actualTask = task;
        }
        public Task getActualTask()
        {
            return actualTask!;
        }

    }
}
