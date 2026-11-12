using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    interface IRepository<T>
        where T : Character
    {
        T GetById(int id);
        IEnumerable<T> GetAll(); //retrieving a collection
        void Add(T value);
        void Update(T value);
        void Remove(int id);
    }
}
