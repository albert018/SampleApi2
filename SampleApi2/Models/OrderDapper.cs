using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi2.Models
{
    public class OrderDapper
    {
        public string Id { get; set; }
        public string Currency { get; set; }
        public bool IsInactive { get; set; }
    }
}
