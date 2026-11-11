using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    interface IRepository<T>
    {
        void add(T value);
        T GetById(int id);
        Collection<T> GetAll(); //retrieving a collection
        void Update(T value);
        void Remove(int id);
    }
}
