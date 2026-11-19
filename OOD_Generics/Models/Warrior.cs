using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics.Models
{
    class Warrior : Character //Inheritance
    {
        public Warrior(int id, string name, char rank, decimal coin) : base(id, name, rank, coin, 100)
        {
            Damage = 27;
        }

        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("Warrior swings sword");
        }
        public override void Dodge()
        {
            Console.WriteLine($"{Name} dodges attack");
        }
    }
}
