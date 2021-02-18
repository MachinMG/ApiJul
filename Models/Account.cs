using ApiJul.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Models
{
    public class Account : IModele
    {
        public Guid Id { get; set; }
        public Guid IdCustomer { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> Validate()
        {
            var repoCustomer = new CustomersRepository();
            if (repoCustomer.Get(IdCustomer) == null) yield return $"Customer with id {IdCustomer} not found.";
        }
    }
}
