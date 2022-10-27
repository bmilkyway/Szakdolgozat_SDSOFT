namespace CRM.Domain.Models
{
    public class Message : DomainObject
    {

        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
        public string? Subject { get; set; }
        public DateTime SendDate { get; set; }
        public bool isRead { get; set; }
        public string? MessageText { get; set; }

        public override string ToString()
        {

            if (isRead)
            {
                return String.Format("{0} - {1}", Subject, SendDate.ToString());
            }
            else
                return String.Format("(Új) {0} - {1}", Subject, SendDate.ToString());
        }


    }
}
