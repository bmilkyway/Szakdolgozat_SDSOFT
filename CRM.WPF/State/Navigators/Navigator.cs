using System.ComponentModel;
using System.Windows.Input;

using CRM.WPF.Commands;
using CRM.WPF.ViewModels;

namespace CRM.WPF.State.Navigators
{
    public class Navigator : INavigator, INotifyPropertyChanged
    {

        private ViewModelBase? _currentViewModelBase;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModelBase!;
            }
            set
            {
                _currentViewModelBase = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpDateCurrentViewModelCommand(this);

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Ha megváltozk a paraméter a CurrentViewModel navigáció esetén, cseréli azt
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
