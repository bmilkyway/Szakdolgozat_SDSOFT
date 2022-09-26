using SQLite;

namespace CRM.LocalDb
{
    public class CurrentUser
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int userId { get; set; }

        public string? name { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
    }
}