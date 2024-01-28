﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApiAutomation.Models
{
    public class CreateAccountRequest
    {
        public int InitialBalance { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
    }
}
