using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;
using CRM.WPF.Services.EmailSender;

namespace CRM.WPF.ViewModels
{
    public class FeedbackForAdminViewModel:ViewModelBase
    {
        public User activeUser { get; set; }
        public List<Feedback> feedbacks { get; set; }
        public List<string> feedbackTitle { get; set; }

        public FeedbackForAdminViewModel()
        {
            activeUser = currentUser;
            feedbackTitle = new List<string>();
            feedbacks = FeedbackService!.GetAll().Result.ToList();
            for (int i = 0; i < feedbacks.Count; i++)
            {
                feedbackTitle.Add(feedbacks[i].ToString());
            }
        }

        public async void readNewFeedback(Feedback feedback, ListBox lbFeedbacks, TextBox txtFilter)
        {
            if ((bool)!feedback.isRead!)
            {
                feedback.isRead = true;
                await FeedbackService!.Update(feedback.Id, feedback);
                feedbacks = FeedbackService!.GetAll().Result.ToList();
                lbFeedbacks.Items.Clear();
                if (!string.IsNullOrEmpty(txtFilter.Text))
                {
                    for (int i = 0; i < feedbacks.Count; i++)
                        if (feedbackTitle[i].Contains(txtFilter.Text))
                        {
                            feedbackTitle[i] = feedbacks[i].ToString();
                            lbFeedbacks.Items.Add(feedbackTitle[i]);
                        }
                }
                else
                    for (int i = 0; i < feedbacks.Count; i++)
                    {
                        feedbackTitle[i] = feedbacks[i].ToString();
                        lbFeedbacks.Items.Add(feedbackTitle[i]);
                    }
                lbFeedbacks.Items.Refresh();
            }

        }
        public async void reviseFeedback(Feedback feedback,ListBox lbFeedbacks, TextBox txtFilter)
        {
            feedback.isRevised = true;
            await FeedbackService!.Update(feedback.Id, feedback);
            User senderUser = UserService!.Get(feedback.FeedbackUserId).Result;
            EmailSender sender = new EmailSender();
            sender.resiveFeedback(senderUser, feedback);
            MessageBox.Show("Visszajelzés státusza sikeresen megváltozott!\nA visszajelzést küldő felhasználó emailben értesülni fog a változásokról!", "Sikeres lezárás!", MessageBoxButton.OK, MessageBoxImage.Information);
            feedbacks = FeedbackService!.GetAll().Result.ToList();
            lbFeedbacks.Items.Clear();
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                for (int i = 0; i < feedbacks.Count; i++)
                    if (feedbackTitle[i].Contains(txtFilter.Text))
                    {
                        feedbackTitle[i] = feedbacks[i].ToString();
                        lbFeedbacks.Items.Add(feedbackTitle[i]);
                    }
            }
            else
                for (int i = 0; i < feedbacks.Count; i++)
                {
                    feedbackTitle[i] = feedbacks[i].ToString();
                    lbFeedbacks.Items.Add(feedbackTitle[i]);
                }
            lbFeedbacks.Items.Refresh();

        }
    }
}
