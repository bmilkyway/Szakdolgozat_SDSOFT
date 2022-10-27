using System.Windows.Input;

using CRM.WPF.ViewModels;

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
        NewMessage,
        SentMessage,
        IncomingMessage,
        NewTask,
        OwnTask,
        AllTask,
        Adminlayout,
        FeedbackForUser

    }



    //Navigációt végző interface
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
