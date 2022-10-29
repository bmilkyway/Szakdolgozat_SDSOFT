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

using CRM.Domain.Models;
using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for FeedbackForAdminsView.xaml
    /// </summary>
    public partial class FeedbackForAdminsView : UserControl
    {
        /// <summary>
        /// View-hoz tartozó viewModel példánya
        /// </summary>
        private readonly FeedbackForAdminViewModel feedbackForAdminViewModel;

        /// <summary>
        /// int lista, amely a visszajelzések indexét tartalmazza, a szűrt listás kereséshez kell
        /// </summary>
        private List<int> filteredFeedbackListId;
        private Feedback? selectedFeedback;
        public FeedbackForAdminsView()
        {
            InitializeComponent();
            filteredFeedbackListId = new List<int>();
            feedbackForAdminViewModel = new FeedbackForAdminViewModel();
            for (int i = 0; i < feedbackForAdminViewModel.feedbacks.Count; i++)
            {
                lbFeedback.Items.Add(feedbackForAdminViewModel.feedbacks[i].ToString());
                filteredFeedbackListId.Add(i);
            }
        }
/// <summary>
/// Kiválasztott visszajelzés részletes megjelenítése
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void setFeedbackViewer(object sender, SelectionChangedEventArgs e)
        {
            if (lbFeedback.SelectedIndex != -1)
            {
                try
                {
                    selectedFeedback = feedbackForAdminViewModel.feedbacks[filteredFeedbackListId[lbFeedback.SelectedIndex]];
                    txtType.Text = selectedFeedback.FeedbackType;
                    txtDate.Text = selectedFeedback.FeedbackDate.ToString();
                    txtFeedbackDescription.Text = selectedFeedback.FeedbackDescription;
                    txtFeedbackName.Text = selectedFeedback.FeedbackName;

                    User senderUser = feedbackForAdminViewModel.UserService!.Get(selectedFeedback.FeedbackUserId).Result;
                    if ((bool)selectedFeedback.isRevised!) btnRevise.IsEnabled = false;
                    else btnRevise.IsEnabled = true;
                    if (senderUser == null || senderUser.PermissionId == 5)
                        txtAddress.Text = "Törölt felhasználó";
                    else
                        txtAddress.Text = senderUser.Name;
                    if((bool)!selectedFeedback.isRead!)
                    feedbackForAdminViewModel.readNewFeedback(selectedFeedback, lbFeedback, txtFilter);
                    
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

                    MessageBox.Show("Nem sikerült megnyitni az adott visszajelzést!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Keresés a visszajelzések listában, szűréssel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterList(object sender, TextChangedEventArgs e)
        {
            lbFeedback.Items.Clear();
            filteredFeedbackListId.Clear();
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                for (int i = 0; i < feedbackForAdminViewModel.feedbacks.Count; i++)
                    if (feedbackForAdminViewModel.feedbackTitle[i].Contains(txtFilter.Text))
                    {
                        lbFeedback.Items.Add(feedbackForAdminViewModel.feedbackTitle[i]);
                        filteredFeedbackListId.Add(i);
                    }
            }
            else
            {
                for (int i = 0; i < feedbackForAdminViewModel.feedbackTitle.Count; i++)
                {
                    lbFeedback.Items.Add(feedbackForAdminViewModel.feedbackTitle[i].ToString());
                    filteredFeedbackListId.Add(i);
                }
            }
        }
        /// <summary>
        /// Visszajelzés lezárása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void feedbackRevise(object sender, RoutedEventArgs e)
        {
            if(selectedFeedback!=null)
            feedbackForAdminViewModel.reviseFeedback(selectedFeedback!, lbFeedback, txtFilter);
        }
    }
}
