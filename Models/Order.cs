using ApiJul.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Models
{
    public class Order : IModele
    {
        public Guid Id { get; set; }
        public Guid IdCustomer { get; set; }
        public IEnumerable<ItemOrdered> Content { get; set; }

        public IEnumerable<string> Validate()
        {
            var repoCustomer = new CustomersRepository();
            if (repoCustomer.Get(IdCustomer) == null) yield return $"Customer with id {IdCustomer} not found.";

            if(!Content.Any()) yield return $"An order cannot be empty.";
        }

        public struct ItemOrdered
        {
            public Guid ItemId { get; set; }
            public int Quantity { get; set; }
            public float UnitPrice { get; set; }
        }
    }
}
