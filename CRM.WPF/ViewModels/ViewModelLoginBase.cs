using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;

namespace CRM.WPF.ViewModels
{
    public class ViewModelLoginBase
    {
        public IDataService<User>? UserService;
        public IDataService<Task>? TaskService;
        public IDataService<Message>? MessageService;
        public IDataService<Status>? StatusService;


        public ViewModelLoginBase()
        {

            UserService = new GenericDataService<User>(new CRM_DbContextFactory());
            TaskService = new GenericDataService<Task>(new CRM_DbContextFactory());
            MessageService = new GenericDataService<Message>(new CRM_DbContextFactory());
            StatusService = new GenericDataService<Status>(new CRM_DbContextFactory());


        }
    }
}
