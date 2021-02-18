using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Models
{
    public interface IModele
    {
        Guid Id { get; set; }
        IEnumerable<string> Validate();
    }
}
