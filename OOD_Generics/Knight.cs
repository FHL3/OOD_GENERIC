using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    class Knight : Character
    {
        public Knight(int id, string name, char rank, decimal coin) : base(id, name, rank, coin)
        {
        }
        public override void Attack()
        {
            Console.WriteLine($"{Name} pounced!");
        }
    }
}
