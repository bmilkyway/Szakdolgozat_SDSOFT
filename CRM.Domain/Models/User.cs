namespace CRM.Domain.Models
{
    public class User : DomainObject
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LoginDate { get; set; }
        public int PermissionId { get; set; }
        public IEnumerable<Message>? Messages { get; set; }
        public IEnumerable<Task>? Tasks { get; set; }

        public override string ToString()
        {
            return String.Format(Name!);
        }

    }
}
