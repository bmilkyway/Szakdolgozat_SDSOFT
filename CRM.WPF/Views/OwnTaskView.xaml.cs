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
    /// Interaction logic for OwnTaskView.xaml
    /// </summary>
    public partial class OwnTaskView : UserControl
    {

        private readonly OwnTaskViewModel ownTaskViewModel;
        public OwnTaskView()
        {
            InitializeComponent();
            ownTaskViewModel = new OwnTaskViewModel();
         //   lbTaskList.ItemsSource = ownTaskViewModel.ownTasks;
        }

        private void openSelectedTask(object sender, SelectionChangedEventArgs e)
        {
            if (lbTaskList.SelectedIndex != -1)
            {
                ActualTaskView actual = new ActualTaskView(ownTaskViewModel.ownTasks[lbTaskList.SelectedIndex],lbTaskList);
                actual.ShowDialog();
                lbTaskList.SelectedIndex = -1;
                ownTaskViewModel.reset();
                ownTaskViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
                lbTaskList.Items.Refresh();
                lbTaskList.ItemsSource = ownTaskViewModel.showFilteredTask;
                lbClosed.Text = String.Format("Lezárt feladatok száma: {0}",ownTaskViewModel.closedTaskCount.Count);
                lbnearDeadline.Text = String.Format("10 napon belül lejár: {0}",ownTaskViewModel.nearDeadline.Count);
                lbOwn.Text = String.Format("Saját feladatok száma: {0}",ownTaskViewModel.ownTasks.Count);
                lbPlanned.Text = String.Format("Tervezés alatt álló feladatok száma: {0}",ownTaskViewModel.plannedTaskCount.Count);

            }
        }

        private void setFilterTaskList(object sender, RoutedEventArgs e)
        {
            ownTaskViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
            lbTaskList.ItemsSource = ownTaskViewModel.showFilteredTask;
        }
    }
}
