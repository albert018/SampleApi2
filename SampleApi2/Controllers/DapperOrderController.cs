using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SampleApi2.Filters;
using SampleApi2.Models;
using SampleApi2.Repositories;
using SampleApi2.Requests;
using SampleApi2.Responses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleApi2.Controllers
{
    [Route("api/dapperOrder")]
    [ApiController]
    public class DapperOrderController : ControllerBase
    {
        private readonly IOrderDapperRepository _orderRepo;

        public DapperOrderController(IOrderDapperRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderRepo.Get());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(string id)
        {
            return Ok(_orderRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Post(OrderRequest request)
        {
            var item = Map(request);

            _orderRepo.Add(item);
            return CreatedAtAction(nameof(Post), new { id = item.Id }, null);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(OrderExistsFilter))]
        public IActionResult Put(string id, OrderRequest request)
        {
            var order = _orderRepo.Get(id);

            var item = Map(request, order);

            _orderRepo.Update(id, item);
            return Ok();
        }

        [HttpPatch("{id:guid}")]
        [ServiceFilter(typeof(OrderExistsFilter))]
        public IActionResult Patch(string id, JsonPatchDocument<OrderDapper> requestOp)
        {
            var item = _orderRepo.Get(id);

            requestOp.ApplyTo(item);
            _orderRepo.Update(id, item);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ServiceFilter(typeof(OrderExistsFilter))]
        public IActionResult Delete(string id)
        {
            var item = _orderRepo.Get(id);

            _orderRepo.Delete(id);
            return NoContent();
        }

        private OrderDapper Map(OrderRequest request)
        {
            return new OrderDapper
            {
                Id = Guid.NewGuid().ToString(),
                Currency = request.Currency
            };
        }

        private OrderDapper Map(OrderRequest request, OrderDapper order)
        {
            order.Currency = request.Currency;
            return order;
        }

        private IEnumerable<OrderResponse> Map(IEnumerable<OrderDapper> order)
        {
            return order.Select(Map);
        }

        private OrderResponse Map(OrderDapper order)
        {
            return new OrderResponse
            {
                Id = new Guid( order.Id),
                Currency = order.Currency
            };
        }
    }
}
