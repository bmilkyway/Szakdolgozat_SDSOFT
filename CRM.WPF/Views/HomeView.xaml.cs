using System;
using System.Windows;
using System.Windows.Controls;

using CRM.WPF.ViewModels;


namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        private readonly HomeViewModel homeViewModel;
        public HomeView()
        {
            InitializeComponent();
            homeViewModel = new HomeViewModel();
        }


        private void setFilterTaskList(object sender, RoutedEventArgs e)
        {
            homeViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
            lbOwnTasks.ItemsSource = homeViewModel.showFilteredTask;
        }

        private void openThisTask(object sender, SelectionChangedEventArgs e)
        {
            if (lbOwnTasks.SelectedIndex != -1)
            {
                ActualTaskView actual = new ActualTaskView(homeViewModel.ownTasks![lbOwnTasks.SelectedIndex], lbOwnTasks);
                actual.ShowDialog();
                lbOwnTasks.SelectedIndex = -1;
                homeViewModel.reset();
                homeViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
                lbOwnTasks.Items.Refresh();
                txtNearDeadline.Text = String.Format("Közelgő határidős feladatok: {0}", homeViewModel.nearTheDeadlineCount.Count);
                lbOwnTasks.ItemsSource = homeViewModel.showFilteredTask;

            }

        }
    }


}
