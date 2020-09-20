using System.Collections.Generic;

namespace Pri.Generics.Core.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T toAdd);
        void Delete(T toDelete);
        IEnumerable<T> GetAll();
        T Get(int index);
    }
}
