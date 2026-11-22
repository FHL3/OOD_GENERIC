using OOD_Generics.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics.Models
{
    class Mage : Character, IHealer
    {
        public Mage(int id, string name, char rank, decimal coin) : base(id, name, rank, coin, 100)
        {
            Damage = 15;
        }
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("Casts Fireball");
        }
        public override async Task AttackAsync()
        {
            await base.AttackAsync();
        }
        public override void Dodge()
        {
            Console.WriteLine($"{Name} dodges attack");
        }
        public override async Task DodgeAsync()
        {
            await base.DodgeAsync();
        }
        public void Heal()
        {
            Console.WriteLine($"{Name} has cast healing");
        }
    }
}
