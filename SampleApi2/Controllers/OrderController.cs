using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SampleApi2.Models;
using SampleApi2.Repositories;
using SampleApi2.Requests;
using SampleApi2.Responses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleApi2.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        
        public OrderController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Map(_orderRepo.Get()));
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Ok(Map(_orderRepo.Get(id)));
        }

        [HttpPost]
        public IActionResult Post(OrderRequest request)
        {
            var item = Map(request);

            _orderRepo.Add(item);
            return CreatedAtAction(nameof(Post), new { id = item.Id }, null);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, OrderRequest request)
        {
            if (null == request.Itemids)
                return BadRequest(new { Message = $"Itemids is null." });

            var order = _orderRepo.Get(id);

            if (null == order)
            {
                return NotFound(new { Message = $"Item with id {id} not exist." });
            }

            var item = Map(request, order);

            _orderRepo.Update(id, item);
            return Ok();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult Patch(Guid id, JsonPatchDocument<Order> requestOp)
        {
            var item = _orderRepo.Get(id);

            if (requestOp == null)
                return NotFound(new { Message = $"{id} not found." });

            requestOp.ApplyTo(item);
            _orderRepo.Update(id, item);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var item = _orderRepo.Get(id);

            if(item==null)
                return NotFound(new { Message = $"{id} not found." });

            _orderRepo.Delete(id);
            return NoContent();
        }

        private Order Map(OrderRequest request)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                Itemids = request.Itemids,
                Currency = request.Currency
            };
        }

        private Order Map(OrderRequest request, Order order)
        {
            order.Itemids = request.Itemids;
            order.Currency = request.Currency;
            return order;
        }

        private IEnumerable<OrderResponse> Map(IEnumerable<Order> order)
        {
            return order.Select(Map);
        }

        private OrderResponse Map(Order order)
        {
            return new OrderResponse
            {
                Id = order.Id,
                Itemids = order.Itemids,
                Currency = order.Currency1
            };
        }
    }
}
