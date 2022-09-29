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
  ActualTask actual = new ActualTask(allTaskViewModel.showFilteredTask[lbTaskList.SelectedIndex],
                (allTaskViewModel.showFilteredTask[lbTaskList.SelectedIndex].ResponsibleUserId!=null && allTaskViewModel.showFilteredTask[lbTaskList.SelectedIndex].ResponsibleUserId ==allTaskViewModel.activeUser.Id)?
                true:false,lbTaskList);
            actual.ShowDialog();
                lbTaskList.Items.Refresh();
            }
          
        }

        private void setFilterTaskList(object sender, RoutedEventArgs e)
        {
            allTaskViewModel.setShowFilteredTask(cbOwn.IsChecked!.Value,cbPlanning.IsChecked!.Value,cbClosed.IsChecked!.Value,cbFree.IsChecked!.Value,cbStarted.IsChecked!.Value,cbExpired.IsChecked!.Value,cbNearDeadline.IsChecked!.Value);
            lbTaskList.ItemsSource = allTaskViewModel.showFilteredTask;
      
        }
    }
}
