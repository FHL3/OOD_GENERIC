using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics.Models
{
    class Rogue : Character
    {
        public Rogue(int id, string name, char rank, decimal coin) : base(id, name, rank, coin, 100)
        { }
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("Swiftly throws a kunai");
        }
        public override void Dodge()
        {
            Console.WriteLine($"{Name} dodges attack");
        }
    }
}
