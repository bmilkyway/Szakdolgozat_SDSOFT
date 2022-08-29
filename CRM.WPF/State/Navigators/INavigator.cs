using CRM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM.WPF.State.Navigators
{


    //Alap menüpontok nézeteinek enumjai
    public enum ViewType
    {
        Home,
        LogOut,
        Message,
        OverView,
        Task,
    }



    //Navigációt végző interface
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
