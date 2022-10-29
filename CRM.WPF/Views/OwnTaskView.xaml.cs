using System;
using System.Windows;
using System.Windows.Controls;

using CRM.WPF.ViewModels;

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
                ActualTaskView actual = new ActualTaskView(ownTaskViewModel.showFilteredTask[lbTaskList.SelectedIndex], lbTaskList);
                actual.ShowDialog();
                lbTaskList.SelectedIndex = -1;
                ownTaskViewModel.reset();
                ownTaskViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
                lbTaskList.Items.Refresh();
                lbTaskList.ItemsSource = ownTaskViewModel.showFilteredTask;
                lbClosed.Text = String.Format("Lezárt feladatok száma: {0}", ownTaskViewModel.closedTaskCount.Count);
                lbnearDeadline.Text = String.Format("10 napon belül lejár: {0}", ownTaskViewModel.nearDeadline.Count);
                lbOwn.Text = String.Format("Saját feladatok száma: {0}", ownTaskViewModel.ownTasks.Count);
                lbPlanned.Text = String.Format("Tervezés alatt álló feladatok száma: {0}", ownTaskViewModel.plannedTaskCount.Count);

            }
        }

        private void setFilterTaskList(object sender, RoutedEventArgs e)
        {
            ownTaskViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
            lbTaskList.ItemsSource = ownTaskViewModel.showFilteredTask;
        }
    }
}
