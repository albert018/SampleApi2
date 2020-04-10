﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi2.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Itemids { get; set; }
        public string Currency { get; set; }
        public bool IsInactive { get; set; }
    }
}
