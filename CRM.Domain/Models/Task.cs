using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Models
{
    public class Task:DomainObject
    {
       
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public string? Category { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public int CreatedUserId { get; set; }
        public int TaskStatusId{ get; set; }
        public int ResponsibleUserId { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1} (Lejárat: {2})",TaskName,Category, DeadLine);
        }

    }
}
