using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Models
{
    public class Customer : IModele
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }

        public IEnumerable<string> Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) yield return "First name is required.";
            if (string.IsNullOrWhiteSpace(LastName)) yield return "Last name is required.";
            if (string.IsNullOrWhiteSpace(Address)) yield return "Address is required.";
            if (string.IsNullOrWhiteSpace(Username)) yield return "Username is required.";
        }
    }
}
