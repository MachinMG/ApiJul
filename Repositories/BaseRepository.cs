using ApiJul.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : IModele
    {
        private LiteDatabase _database;
        protected string _nomCollection;
        private ILiteCollection<T> _collection;

        public BaseRepository()
        {
            var root = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);
            var dir = Path.Combine(root, "data");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            _database = new LiteDatabase(Path.Combine(dir, "data.db"));
            _collection = _database.GetCollection<T>(_nomCollection);
            _collection.EnsureIndex(x => x.Id);
        }

        public virtual T Create(T item)
        {
            var id = _collection.Insert(item);
            return Get(id);
        }

        public virtual void Delete(Guid id)
        {
            _collection.Delete(id);
        }

        public virtual IEnumerable<T> Get()
        {
            return _collection.FindAll().ToList();
        }

        public virtual T Get(Guid id)
        {
            return _collection.FindById(id);
        }

        public virtual T Update(T item)
        {
            var id = item.Id;
            _collection.Update(item);
            return Get(id);
        }

        public void Dispose()
        {
            if (_database != null) _database.Dispose();
        }
    }
}
