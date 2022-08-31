using CRM.WPF.Controls;
using CRM.WPF.State.Navigators;
using CRM.WPF.ViewModels;
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

        public UpDateCurrentViewModelCommand(INavigator navigator)
        {
            
            _navigator = navigator;
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
                    case ViewType.LogOut:
                        Application.Current.Shutdown();
                        break;
                }
            }
        }
    }
}
