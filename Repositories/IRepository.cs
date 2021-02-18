using ApiJul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Repositories
{
    public interface IRepository<T> where T : IModele
    {
        IEnumerable<T> Get();
        T Get(Guid id);
        T Create(T item);
        void Delete(Guid id);
        T Update(T item);
    }
}
