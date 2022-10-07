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
    /// Interaction logic for AllTaskView.xaml
    /// </summary>
    public partial class AllTaskView : UserControl
    {

        private readonly AllTaskViewModel allTaskViewModel;
        public AllTaskView()
        {
            InitializeComponent();
            allTaskViewModel = new AllTaskViewModel();
            
        }

        private void openActualTaskWindow(object sender, SelectionChangedEventArgs e)
        {
            if (lbTaskList.SelectedIndex != -1)
            {
                ActualTaskView actual = new ActualTaskView(allTaskViewModel.showFilteredTask[lbTaskList.SelectedIndex],lbTaskList);
                actual.ShowDialog();
                lbTaskList.SelectedIndex = -1;
                allTaskViewModel.reset();
                allTaskViewModel.setShowFilteredTask(cbOwn.IsChecked!.Value, cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbFree.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
                lbTaskList.Items.Refresh();
                lbTaskList.ItemsSource = allTaskViewModel.showFilteredTask;
                lbAll.Text = String.Format("Feladatok száma: {0}",allTaskViewModel.allTask.Count);
                lbOwn.Text = String.Format("Ebből saját: {0}",allTaskViewModel.ownTask.Count);
                lbClosed.Text = String.Format("Lezárt feladatok száma: {0}",allTaskViewModel.closedTask.Count);
                lbFree.Text = String.Format("Szabad feladatok száma: {0}",allTaskViewModel.freeTask.Count);
                lbPlanned.Text = String.Format("Tervezés alatt álló feladatok száma: {0}",allTaskViewModel.plannedTask.Count);
                lbNearDeadline.Text = String.Format("10 napon belül lejár: {0}",allTaskViewModel.nearDeadlineTask.Count);
            }
          
        }

        private void setFilterTaskList(object sender, RoutedEventArgs e)
        {
            allTaskViewModel.setShowFilteredTask(cbOwn.IsChecked!.Value,cbPlanning.IsChecked!.Value,cbClosed.IsChecked!.Value,cbFree.IsChecked!.Value,cbStarted.IsChecked!.Value,cbExpired.IsChecked!.Value,cbNearDeadline.IsChecked!.Value);
            lbTaskList.ItemsSource = allTaskViewModel.showFilteredTask;
        }
    }
}
