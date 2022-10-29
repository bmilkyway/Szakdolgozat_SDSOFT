using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;
using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for FeedbackForUserView.xaml
    /// </summary>
    public partial class FeedbackForUserView : UserControl
    {
        /// <summary>
        /// Visszajelzések típusait tartalmazó lista
        /// </summary>
        private List<string> feedbackTypes = new List<string>() { "Hiba", "Javaslat", "Köszönet", "Bug" };

        /// <summary>
        /// View-hoz tarozó viewModel példánya
        /// </summary>
        private readonly FeedbackForUsersViewModel feedbackForUserViewModel;
        public FeedbackForUserView()
        {
            InitializeComponent();
            cbFeedbackType.ItemsSource = feedbackTypes;
            feedbackForUserViewModel = new FeedbackForUsersViewModel();
        }
        /// <summary>
        /// Elküldi a visszajel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendFeedback(object sender, RoutedEventArgs e)
        {
            if(txtFeedbackName.Text=="" || txtTaskDescription.Text=="" || cbFeedbackType.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs minden adat kitöltve!","Hiba!",MessageBoxButton.OK,MessageBoxImage.Error);
                return;   
            }
            Feedback feedback = new Feedback
            {
                FeedbackType = cbFeedbackType.SelectedItem.ToString(),
                FeedbackDate = DateTime.Now,
                FeedbackUserId = feedbackForUserViewModel.activeUser.Id,
                FeedbackName = txtFeedbackName.Text,
                isRead = false,
                isRevised = false,
                FeedbackDescription = txtTaskDescription.Text
                
            };
            if (feedbackForUserViewModel.sendFeedBack(feedback))
            {
                txtTaskDescription.Text = "";
                txtFeedbackName.Text = "";
                cbFeedbackType.SelectedIndex = -1;
            }
        }
    }
}
