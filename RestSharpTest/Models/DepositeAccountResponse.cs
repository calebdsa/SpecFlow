﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Models
{
    public class DepositeAccountResponse
    {
        public Data Data { get; set; }
        public string Message { get; set; }
        public List<object> Errors { get; set; }
    }
}
