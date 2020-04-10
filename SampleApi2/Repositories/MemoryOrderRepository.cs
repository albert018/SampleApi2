using SampleApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi2.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {
        private IList<Order> _orders;

        public MemoryOrderRepository()
        {
            _orders = new List<Order>();
        }

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public Order Delete(Guid id)
        {
            var result = _orders.FirstOrDefault(x => x.Id == id);
            result.IsInactive = true;
            return result;
        }

        public IEnumerable<Order> Get()
        {
            return _orders.Where(x => !x.IsInactive);
        }

        public Order Get(Guid id)
        {
            return _orders.Where(x => !x.IsInactive).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Guid id, Order order)
        {
            var result = _orders.FirstOrDefault(x => x.Id == id);
            if (result != null)
                result.Itemids = order.Itemids;
        }
    }
}
