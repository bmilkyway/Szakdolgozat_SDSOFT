using CRM.WPF.State.Navigators;

namespace CRM.WPF.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public TaskViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.OwnTask);
        }
    }
}
