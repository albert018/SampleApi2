using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi2.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Itemids { get; set; }
        public string Currency { get; set; }
    }
}
