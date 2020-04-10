using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi2.Models;

namespace SampleApi2.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();
        Order Get(Guid id);
        void Add(Order order);
        void Update(Guid id, Order order);
        Order Delete(Guid id);
    }
}
