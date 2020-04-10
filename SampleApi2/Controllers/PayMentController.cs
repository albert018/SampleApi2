using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi2.Interface;
using SampleApi2.Service;

namespace SampleApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMentController : ControllerBase
    {
        private IPayMent _payment { get; set; }
        private readonly PaymentService _paymentService;

        public PayMentController(IPayMent payment, PaymentService paymentService)
        {
            _payment = payment;
            _paymentService = paymentService;
        }
        public string Get()
        {
            return _payment.PayMent() + "#" + _payment.PayMent()+"@@"+_paymentService.GetPayMent();
        }
    }
}