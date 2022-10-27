using System;
using System.Windows;
using System.Windows.Controls;

using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for NewTaskView.xaml
    /// </summary>
    public partial class NewTaskView : UserControl
    {

        private readonly NewTaskViewModel newTaskViewModel;
        public NewTaskView()
        {
            InitializeComponent();
            newTaskViewModel = new NewTaskViewModel();
            cbTaskCategory.ItemsSource = newTaskViewModel.Categories;
            dpDeadline.SelectedDate = DateTime.Now;
        }
        private void saveNewTask(object sender, RoutedEventArgs e)
        {
            if (newTaskViewModel.savewTask(txtTaskName.Text, cbTaskCategory.SelectedIndex, dpDeadline.SelectedDate!.Value, txtTaskDescription.Text, rbPlanning.IsChecked == true ? true : false))
            {
                txtTaskDescription.Text = "";
                txtTaskName.Text = "";
                cbTaskCategory.SelectedIndex = -1;
                rbPlanning.IsChecked = true;
            }
        }
    }
}
