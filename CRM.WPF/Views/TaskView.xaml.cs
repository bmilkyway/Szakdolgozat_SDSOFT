using System.Windows;
using System.Windows.Controls;

using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {
        private readonly TaskViewModel taskViewModel;
        public TaskView()
        {
            InitializeComponent();
            taskViewModel = new TaskViewModel();
            if (taskViewModel.currentUser.PermissionId == 3)
            {
                btnNewTask.Visibility = Visibility.Hidden;
            }
        }
    }
}
