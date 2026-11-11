using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    class Box<T>
    {
        private T value;
        public Box(T value)
        {
            this.value = value;
        }
    }
}
