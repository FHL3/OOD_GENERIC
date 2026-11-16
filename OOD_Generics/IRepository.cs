using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll(); //retrieving a collection
        void Add(T value);
        void Update(T value);
        void Remove(int id);
    }
}
