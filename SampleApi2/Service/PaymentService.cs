using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi2.Interface;
using SampleApi2.Implement;

namespace SampleApi2.Service
{
    public class PaymentService
    {
        private readonly IPayMent _payment;
        public PaymentService(IPayMent payment)
        {
            _payment = payment;
        }

        public string GetPayMent()
        {
            return _payment.PayMent();
        }
    }
}
