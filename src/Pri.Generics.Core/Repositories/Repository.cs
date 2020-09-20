using System.Collections.Generic;
using Pri.Generics.Core.Interfaces;

namespace Pri.Generics.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> _data = new List<T>();

        public void Add(T toAdd)
        {
            _data.Add(toAdd);
        }

        public void Delete(T toDelete)
        {
            _data.Remove(toDelete);
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T Get(int index)
        {
            return _data[index];
        }
    }
}
