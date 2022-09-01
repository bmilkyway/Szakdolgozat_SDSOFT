using CRM.WPF.State.Navigators;


namespace CRM.WPF.ViewModels
{
    public class MessageViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MessageViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.IncomingMessage);
        }
    }
}
