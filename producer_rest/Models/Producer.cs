using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace producer_rest.Models
{
    public class Producer
    {
        public int id { get; set; }
        public string email { get; set; }

        public string password { get; set; }

        public int task { get; set; } 
    }
}
