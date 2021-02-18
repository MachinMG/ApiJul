using ApiJul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository()
        {
            _nomCollection = "customers";
        }
    }
}
