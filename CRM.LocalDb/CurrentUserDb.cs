﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace CRM.LocalDb
{
     class CurrentUserDb
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string?email { get; set; }

       
    }
}
