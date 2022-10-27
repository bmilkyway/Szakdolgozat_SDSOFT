using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CRM.Domain.Models;
using CRM.WPF.State.Navigators;
using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for ActualTaskOpen.xaml
    /// </summary>
    public partial class ActualTaskOpenView :UserControl
    {
        private readonly ActualTaskOpenViewModel actualTaskOpenViewModel;


        private readonly Task actualTask;
        public ActualTaskOpenView()
        {
            InitializeComponent();
            actualTaskOpenViewModel = new ActualTaskOpenViewModel();

            actualTask = new Task();
        }

        private void taskClose(object sender, RoutedEventArgs e)
        {
            if (actualTaskOpenViewModel.taskClose(actualTask))
            {
                
                MessageBox.Show("Sikeresen lezárta a feladatot!");
                
            }
            else
            {
                MessageBox.Show("Nem sikerült lezárni a feladatot!");
            }
        }

        private void takeOnTask(object sender, RoutedEventArgs e)
        {
            if (actualTaskOpenViewModel.takeOnTask(actualTask,actualTaskOpenViewModel.currentUser))
               MessageBox.Show("Sikeresen elvállalta a feladatot!");

            
            else
                MessageBox.Show("Nem sikerült elvállalni a feladatot!");
            
        }
    }
}
