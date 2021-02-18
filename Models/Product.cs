using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Models
{
    public class Product : IModele
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        public IEnumerable<string> Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) yield return "Name is required.";
            if (string.IsNullOrWhiteSpace(Description)) yield return "Description is required.";
        }
    }
}
