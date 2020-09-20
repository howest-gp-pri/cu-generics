using System.Collections.Generic;
using Pri.Generics.Core.Entities;

namespace Pri.Generics.Core.Repositories
{
    public class PersonRepository<T> where T : Person
    {
        private readonly List<T> _data = new List<T>();

        public void Add(T toAdd)
        {
            _data.Add(toAdd);
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }
    }
}
