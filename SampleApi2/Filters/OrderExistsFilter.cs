using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi2.Repositories;

namespace SampleApi2.Filters
{
    public class OrderExistsFilter : IActionFilter
    {
        private readonly IOrderRepository _orderRepo;

        public OrderExistsFilter(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("id"))
                context.Result = new BadRequestObjectResult("ID is null");

            var id = new Guid(context.ActionArguments["id"].ToString());

            var order = _orderRepo.Get(id);

            if (null == order)
            {
                context.Result = new BadRequestObjectResult($"Item with id {id} not exist.");
            }
        }
    }
}
