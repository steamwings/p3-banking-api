﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.API.Models
{
    public class Account
    {
        public int Id {get; set;}
        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateDate {get; set;}
    }
}
