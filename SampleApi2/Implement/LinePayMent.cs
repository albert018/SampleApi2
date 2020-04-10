using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi2.Interface;

namespace SampleApi2.Implement
{
    public class LinePayMent : IPayMent
    {
        private int _count;
        public LinePayMent()
        {
            _count = 1;
        }
        public string PayMent()
        {
            return _count++.ToString();
        }
    }
}
