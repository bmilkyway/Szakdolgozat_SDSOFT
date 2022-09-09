using CRM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            if(newTaskViewModel.savewTask(txtTaskName.Text, cbTaskCategory.SelectedIndex, dpDeadline.SelectedDate!.Value, txtTaskDescription.Text, rbPlanning.IsChecked == true ? true : false))
            {
                txtTaskDescription.Text = "";
                txtTaskName.Text = "";
                cbTaskCategory.SelectedIndex = -1;
                rbPlanning.IsChecked=true;
            }
        }
    }
}
