
using System;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;
using CRM.WPF.ViewModels.ActualTaskViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for ActualTaskView.xaml
    /// </summary>
    public partial class ActualTaskView : Window
    {
        private readonly ActualTaskViewModel actualTaskViewModel = new ActualTaskViewModel();
        public Task actualTask;
        private ListBox lbTasks;
        private string? responsibleUserName;
        public ActualTaskView(Task actualTask, ListBox lbTasks)
        {
            InitializeComponent();
            DataContext = actualTaskViewModel;
            this.Title = actualTask.TaskName;
            this.actualTask = actualTask;
            this.lbTasks = lbTasks;


            if (actualTask.ResponsibleUserId != null && actualTask.ResponsibleUserId == actualTaskViewModel.currentUser.Id)
            {
                responsibleUserName = actualTaskViewModel.currentUser.Name!;

                btnClose.IsEnabled = true;
                btnModify.IsEnabled = true;
                btnTakeOn.IsEnabled = false;
                btnGive.IsEnabled = true;

            }
            else if (actualTask.ResponsibleUserId != null)
            {
                responsibleUserName = actualTaskViewModel.UserService!.Get(actualTask.ResponsibleUserId!.Value).Result.Name!;

                btnClose.IsEnabled = false;
                btnModify.IsEnabled = false;
                btnTakeOn.IsEnabled = false;
                btnGive.IsEnabled = false;
            }
            else
            {
                btnTakeOn.IsEnabled = true;
                btnClose.IsEnabled = false;
                btnModify.IsEnabled = false;
                btnGive.IsEnabled = false;

            }
            switch (actualTask.TaskStatusId)
            {
                case 1:
                    {
                        txtStatus.Text = "Tervezés alatt";
                        break;
                    }
                case 2:
                    {
                        txtStatus.Text = "Szabad";
                        break;

                    }
                case 3:
                    {
                        txtStatus.Text = "Elvállalt";
                        break;

                    }
                case 4:
                    {
                        txtStatus.Text = "Lezárt";
                        btnTakeOn.IsEnabled = false;
                        btnClose.IsEnabled = false;
                        btnModify.IsEnabled = false;
                        btnGive.IsEnabled = false;
                        break;

                    }
            }
            switch (actualTask.Category)
            {
                case "Programozás":
                    {

                        cbCategory.SelectedIndex = 0;
                        break;
                    }
                case "Tesztelés":
                    {
                        cbCategory.SelectedIndex = 1;
                        break;
                    }
                case "Karbantartás":
                    {
                        cbCategory.SelectedIndex = 2;
                        break;
                    }
            }

            txtDeadline.Text = actualTask.DeadLine.ToString();
            txtResponsibleUser.Text = actualTask.ResponsibleUserId == null ? "Nincs felelős" : responsibleUserName;
            txtCategory.Text = actualTask.Category;
            txtCreatedDate.Text = actualTask.CreateDate.ToString();
            tbTaskDescription.Text = actualTask.TaskDescription;

        }

        /// <summary>
        /// Aktuális feladat lezárása, ha tervezés alatti feladatot zárunk le,
        /// akkor utána lesz teljesen végrehajtható, ha végrehajtható feladatot 
        /// zárunk le utána már nem lehet újra elvállalni.
        /// Csak az tudja lezárni a feladatot aki felvette az adott feladatot, illetve csak elvállalt feladatot lehet lezárni.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskClose(object sender, RoutedEventArgs e)
        {
            if (actualTaskViewModel.taskClose(actualTask, lbTasks))
            {
                MessageBox.Show("Sikeresen lezárta a feladatot!");
                this.Close();
            }
            else
                MessageBox.Show("Nem sikerült lezárni a feladatot!");

        }

        private void takeOnTask(object sender, RoutedEventArgs e)
        {
            if (actualTaskViewModel.takeOnTask(actualTask, actualTaskViewModel.currentUser, lbTasks))
            {
                MessageBox.Show("Sikeresen elvállalta a feladatot!");
                this.Close();
            }
            else
                MessageBox.Show("Nem sikerült elvállalni a feladatot!");
        }

        private void startModify(object sender, RoutedEventArgs e)
        {
            txtCategory.Visibility = Visibility.Hidden;
            cbCategory.Visibility = Visibility.Visible;
            tbTaskDescription.IsEnabled = true;
            txtDeadline.IsEnabled = true;
            cbCategory.Text = actualTask.Category;
            cbResponsibleUser.Text = actualTaskViewModel.currentUser.Name;
            spModify.Visibility = Visibility.Visible;
            spOpen.Visibility = Visibility.Hidden;
        }

        private void taskSave(object sender, RoutedEventArgs e)
        {
            if (actualTaskViewModel.taskModify(actualTask, lbTasks, Convert.ToDateTime(txtDeadline.Text), cbCategory.Text, tbTaskDescription.Text))
            {
                MessageBox.Show("Sikeresen módosította a feladat részleteit!", "Sikeres módosítás!", MessageBoxButton.OK);
                cancel();
            }
            else cancel();
        }

        private void taskCancel(object sender, RoutedEventArgs e)
        {
            this.cancel();
        }

        private void cancel()
        {
            txtCategory.Visibility = Visibility.Visible;
            cbCategory.Visibility = Visibility.Hidden;
            tbTaskDescription.IsEnabled = false;
            txtDeadline.IsEnabled = false;
            txtDeadline.Text = actualTask.DeadLine.ToString();
            tbTaskDescription.Text = actualTask.TaskDescription;
            spModify.Visibility = Visibility.Hidden;
            spOpen.Visibility = Visibility.Visible;
            spGive.Visibility = Visibility.Hidden;
            cbResponsibleUser.Visibility = Visibility.Hidden;
            txtResponsibleUser.Visibility = Visibility.Visible;
        }

        private void taskGiveOtherUser(object sender, RoutedEventArgs e)
        {
            txtResponsibleUser.Visibility = Visibility.Hidden;
            cbResponsibleUser.Visibility = Visibility.Visible;
            cbResponsibleUser.Text = txtResponsibleUser.Text;

            spGive.Visibility = Visibility.Visible;
            spOpen.Visibility = Visibility.Hidden;
        }

        private void taskCancelGive(object sender, RoutedEventArgs e)
        {
            this.cancel();
        }

        private void taskSaveGiveOtherUser(object sender, RoutedEventArgs e)
        {
            if (actualTaskViewModel.taskTakeOn(actualTask, lbTasks, actualTaskViewModel.users[cbResponsibleUser.SelectedIndex]))
            {
                MessageBox.Show("Sikeresen átadta a feladatot!", "Sikeres átadás");
                this.Close();
            }
            else
                this.cancel();


        }
    }
}
