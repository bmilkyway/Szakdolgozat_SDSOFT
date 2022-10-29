using CRM.WPF.State.Navigators;

namespace CRM.WPF.ViewModels
{
    public class AdminLayoutViewModel : ViewModelBase
    {


        public INavigator Navigator { get; set; } = new Navigator();
        public AdminLayoutViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.UserSettingsForAdmin);
        }

      
    }
}
