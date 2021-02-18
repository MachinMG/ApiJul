using ApiJul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository()
        {
            _nomCollection = "orders";
        }
    }
}
