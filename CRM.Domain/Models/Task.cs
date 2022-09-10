﻿using System;
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
        public int? ResponsibleUserId { get; set; }

        public override string ToString()
        {
            if (TaskStatusId == 1)
                return String.Format("{0}/{1} - Tervezés alatt (Határidő: {2})", TaskName, Category, DeadLine);
            else if (TaskStatusId == 2)
                return String.Format("{0}/{1} - Szabad (Határidő: {2})", TaskName, Category, DeadLine);
            else if (TaskStatusId == 3)
                return String.Format("{0}/{1} - Elkezdett (Határidő: {2})", TaskName, Category, DeadLine);
            else 
                return String.Format("{0}/{1} - Lezárt (Határidő: {2})", TaskName, Category, DeadLine);

        }

    }
}
