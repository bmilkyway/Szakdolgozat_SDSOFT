using System;
using System.Windows;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class FeedbackForUsersViewModel : ViewModelBase
    {
        public User activeUser { get; set; }
        public FeedbackForUsersViewModel()
        {
            activeUser = currentUser;
        }
        /// <summary>
        /// Létrehozza a visszajelzést
        /// </summary>
        /// <param name="feedback">Visszajelzés objektum</param>
        public bool sendFeedBack(Feedback feedback)
        {
            try
            {
                FeedbackService!.Create(feedback);
                MessageBox.Show("Sikeresen elküldte a visszajelzést!", "Sikeres küldés", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Nem sikerült elküldeni a visszajelzést valamilyen váratlan hiba miatt!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           
        }
    }
}
