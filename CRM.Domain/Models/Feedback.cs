namespace CRM.Domain.Models
{
    public class Feedback : DomainObject
    {
        public int FeedbackUserId { get; set; }
        public string? FeedbackDescription { get; set; }
        public double? Rate { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public bool? isRead { get; set; }
        public string? FeedbackType { get; set; }
        public bool? isRevised { get; set; }
    }
}
