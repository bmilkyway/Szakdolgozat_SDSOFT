using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;
using CRM.LocalDb;
using CRM.WPF.Controls;
using CRM.WPF.State.Navigators;
using CRM.WPF.ViewModels;

using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRM.WPF.Commands
{
    public class UpDateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private IDataService<User>? UserService;
        public UpDateCurrentViewModelCommand(INavigator navigator)
        {
            
            _navigator = navigator;
            UserService = new GenericDataService<User>(new CRM_DbContextFactory());

        }
              
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Message:
                        _navigator.CurrentViewModel = new MessageViewModel();
                        break;
                    case ViewType.OverView:
                        _navigator.CurrentViewModel = new OverViewViewModel();
                        break;
                    case ViewType.Task:
                        _navigator.CurrentViewModel = new TaskViewModel();
                        break;
                    case ViewType.NewMessage:
                        _navigator.CurrentViewModel = new NewMessageViewModel();
                        break;
                    case ViewType.SentMessage:
                        _navigator.CurrentViewModel = new SentMessageViewModel();
                        break;
                    case ViewType.IncomingMessage:
                        _navigator.CurrentViewModel = new IncomingMessageViewModel();
                        break;
                    case ViewType.NewTask:
                        _navigator.CurrentViewModel = new NewTaskViewModel();
                        break;
                    case ViewType.AllTask:
                        _navigator.CurrentViewModel = new AllTaskViewModel();
                        break;
                    case ViewType.OwnTask:
                        _navigator.CurrentViewModel = new OwnTaskViewModel();
                        break;
                        
                    case ViewType.Adminlayout:
                        _navigator.CurrentViewModel = new AdminLayoutViewModel();
                        break;
                    case ViewType.LogOut:

                        Window window = Application.Current.MainWindow;
                        logout();
                        Window loginWindow = new Login();
                        loginWindow.Show();
                        window.Close();
                        break;

                  
                }
            }
        }

        public void logout()
        {
            var db = new SQLiteConnection("currentUserDb.db3");
            CurrentUser currentUser = db!.Get<CurrentUser>(1);
            User user = UserService!.Get(currentUser.userId).Result;
            user.IsActive = false;
            _ = UserService!.Update(user!.Id, user);
            db!.Delete<CurrentUser>(1);
            db!.Close();
            System.IO.File.Delete("currentUserDb.db3");
      
        }
    }
}
