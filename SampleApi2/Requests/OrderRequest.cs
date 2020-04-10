using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleApi2.Requests
{
    public class OrderRequest
    {
        [Required]
        public IEnumerable<string> Itemids { get; set; }
        [Required]
        [Currency]
        public string Currency { get; set; }
    }
}
