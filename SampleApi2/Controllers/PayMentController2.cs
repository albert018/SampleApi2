using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi2.Interface;

namespace SampleApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMent2Controller : ControllerBase
    {
        private IPayMent _payment { get; set; }

        public PayMent2Controller(IPayMent payment)
        {
            _payment = payment;
        }
        public string Get()
        {
            return _payment.PayMent() + "#" + _payment.PayMent();
        }
    }
}