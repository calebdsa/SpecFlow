using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Models
{
    public class CreateAccountResponse
    {
        public AccountData Data { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public string AccountNumber { get; internal set; }
    }
}
