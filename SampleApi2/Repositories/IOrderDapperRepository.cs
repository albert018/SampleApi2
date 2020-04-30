using SampleApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi2.Repositories
{
    public interface IOrderDapperRepository
    {
        IEnumerable<OrderDapper> Get();
        OrderDapper Get(string id);
        void Add(OrderDapper order);
        void Update(string id, OrderDapper order);
        OrderDapper Delete(string id);
    }
}
