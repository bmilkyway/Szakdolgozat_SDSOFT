using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Models
{
    public class Message :DomainObject
    {
       
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
        public string? Subject { get; set; }
        public DateTime SendDate { get; set; }
        public bool isRead { get; set; }
        public string? MessageText { get; set; }
       

    }
}
