namespace CRM.Domain.Models
{
    public class Feedback : DomainObject
    {
        public int FeedbackUserId { get; set; }
        public string? FeedbackDescription { get; set; }
        public string? FeedbackName { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public bool? isRead { get; set; }
        public string? FeedbackType { get; set; }
        public bool? isRevised { get; set; }
        public override string ToString()
        {
            return isRead == true ? String.Format("{0} - {1}/{2} ({3})", FeedbackName,FeedbackType, isRevised == true ? "Kész" : "Kért", FeedbackDate.ToString()) : String.Format("(Új) {0} - {1}/{2} ({3})", FeedbackName, FeedbackType, "Kért", FeedbackDate.ToString());
        }
    }
}
