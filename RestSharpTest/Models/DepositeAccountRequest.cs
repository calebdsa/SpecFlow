using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Models
{
    public class DepositeAccountRequest
    {
        public string AccountNumber { get; set; }
        public int Amount { get; set; }
    }
}
