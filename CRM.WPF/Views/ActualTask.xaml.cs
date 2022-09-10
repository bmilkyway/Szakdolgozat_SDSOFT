using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;
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
        private readonly IDataService<User>? responsibleUser;
        public ActualTask(Domain.Models.Task actualTask)
        {
            InitializeComponent();
            this.Title = actualTask.TaskName;
            switch (actualTask.TaskStatusId)
            {
                case 1:
                    {
                        txtStatus.Text += "Tervezés alatt";
                        break;
                    }
                case 2:
                    {
                        txtStatus.Text += "Szabad";
                        break;
                    }
                case 3:
                    {
                        txtStatus.Text += "Elvállalt";
                        break;
                    }
                case 4:
                    {
                        txtStatus.Text += "Lezárt";
                        break;
                    }
            }
            txtCreatedDate.Text+= actualTask.CreateDate.ToString();
            txtDeadline.Text+= actualTask.DeadLine.ToString();
            tbTaskDescription.Text+= actualTask.TaskDescription;
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
    }
}
