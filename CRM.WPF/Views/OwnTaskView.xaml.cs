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
            lbTaskList.ItemsSource = ownTaskViewModel.ownTasks;
        }
    }
}
