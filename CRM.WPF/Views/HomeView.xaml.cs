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
        /// <summary>
        /// View-hoz tartozó viewModel példánya
        /// </summary>
        private readonly HomeViewModel homeViewModel;
        public HomeView()
        {
            InitializeComponent();
            homeViewModel = new HomeViewModel();
        }

        /// <summary>
        /// Beállítja a szűrt feladatlistát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setFilterTaskList(object sender, RoutedEventArgs e)
        {
            homeViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
            lbOwnTasks.ItemsSource = homeViewModel.showFilteredTask;
        }
        /// <summary>
        /// Megnyitja a kiválasztott feladatot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openThisTask(object sender, SelectionChangedEventArgs e)
        {
            if (lbOwnTasks.SelectedIndex != -1)
            {
                ActualTaskView actual = new ActualTaskView(homeViewModel.showFilteredTask![lbOwnTasks.SelectedIndex], lbOwnTasks);
                actual.ShowDialog();
                lbOwnTasks.SelectedIndex = -1;
                homeViewModel.reset();
                homeViewModel.setShowFilteredTask(cbPlanning.IsChecked!.Value, cbClosed.IsChecked!.Value, cbStarted.IsChecked!.Value, cbExpired.IsChecked!.Value, cbNearDeadline.IsChecked!.Value);
                lbOwnTasks.Items.Refresh();
                txtNearDeadline.Text = String.Format("Közelgő határidős feladatok: {0}", homeViewModel.nearTheDeadlineCount.Count);
                lbOwnTasks.ItemsSource = homeViewModel.showFilteredTask;
                pieChart.Series = homeViewModel.tasksChart.SeriesCollection;
            }

        }
    }


}
