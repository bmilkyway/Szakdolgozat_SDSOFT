using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;
using CRM.WPF.ViewModels.ActualTaskViewModels;
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
using System.Windows.Shapes;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for ActualTask.xaml
    /// </summary>
    public partial class ActualTask : Window
    {
        private readonly ActualTaskViewModel actualTaskViewModel;
        private readonly IDataService<User>? responsibleUser;
        public User user;
        private Domain.Models.Task actualTask;
        public ActualTask(Domain.Models.Task actualTask, bool isOwnTask, User user)
        {
            InitializeComponent();
            actualTaskViewModel = new ActualTaskViewModel();
            this.Title = actualTask.TaskName;
            this.user = user;
            this.actualTask = actualTask;
            switch (actualTask.TaskStatusId)
            {
                case 1:
                    {
                   
                        txtStatus.Text += "Tervezés alatt";
                      
                        btnClose.Content = "Tervezés lezárása";
                        break;

                    }
                case 2:
                    {
                        btnTakeOn.IsEnabled = true;
                        txtStatus.Text += "Szabad";
                        break;
                       
                    }
                case 3:
                    {
                      
                        txtStatus.Text += "Elvállalt";
                        if (!isOwnTask)
                        {

                            btnTakeOn.IsEnabled = false;
                        }
                        break;
                    }
                case 4:
                    {
                        btnTakeOn.IsEnabled = false;
                        btnModify.IsEnabled = false;
                        btnGive.IsEnabled = false;
                        btnClose.IsEnabled = false;
                        txtStatus.Text += "Lezárt";
                        break;
                    }
            }
            txtCreatedDate.Text+= actualTask.CreateDate.ToString();
            txtDeadline.Text+= actualTask.DeadLine.ToString();
            tbTaskDescription.Text+= actualTask.TaskDescription;
            txtCategory.Text += actualTask.Category;
            if (actualTask.ResponsibleUserId == null)
            {
                txtResponsibleUser.Text = "Nincs";
            }
            else
            {
                responsibleUser = new GenericDataService<User>(new CRM_DbContextFactory());
                txtResponsibleUser.Text +=responsibleUser.Get(actualTask.ResponsibleUserId.Value).Result.Name ;
            }
        }

        private void takeOnTask(object sender, RoutedEventArgs e)
        {
           if( actualTaskViewModel.takeOnTask(actualTask, user))
            {
                MessageBox.Show("Sikersen elvállalta!");
                this.Close();
            }
        }

        private void taskClose(object sender, RoutedEventArgs e)
        {
            if (actualTaskViewModel.taskClose(actualTask))
            {
                MessageBox.Show("Sikersen lezárta!");
                this.Close();
            }
        }
    }
}
