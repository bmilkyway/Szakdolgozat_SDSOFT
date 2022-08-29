using CRM.WPF.Commands;
using CRM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM.WPF.State.Navigators
{
    public class Navigator : INavigator,INotifyPropertyChanged
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
        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
