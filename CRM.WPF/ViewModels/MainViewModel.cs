using CRM.Domain.Models;
using CRM.WPF.State.Navigators;


namespace CRM.WPF.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

       public MainViewModel(User activeUser)
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
