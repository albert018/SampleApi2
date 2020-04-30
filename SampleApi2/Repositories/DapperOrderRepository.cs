using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SampleApi2.Models;

namespace SampleApi2.Repositories
{
    public class DapperOrderRepository : IOrderDapperRepository
    {
        private readonly SqlConnection _con;

        public DapperOrderRepository()
        {

            _con = new SqlConnection(@"server=localhost;database=Product;uid=sa;pwd=Pass.123");
        }

        public void Add(OrderDapper order)
        {
            
            throw new NotImplementedException();
        }

        public OrderDapper Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDapper> Get()
        {
            var result =  _con.Query<OrderDapper>("select * from [order]");
            return result;
        }

        public OrderDapper Get(string id)
        {
            return _con.QuerySingle<OrderDapper>("select * from [order] where id = @id",new { id = id });
        }

        public void Update(string id, OrderDapper order)
        {
            throw new NotImplementedException();
        }
    }
}
