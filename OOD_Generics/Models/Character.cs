using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics.Models
{
    public class Character
    {
        public int ID { get;}
        public string Name { get; set; }    
        public char Rank { get; set; }
        private decimal Coin { get; set;} //encapsulation
        public int Health { get; private set; }
        public int Damage {  get; protected set; }
        public int GuildId { get; set; }
        public int WeapId { get; set; }
        
        public Character(int id, string name, char rank, decimal coin, int startHealth)
        {
            ID = id;
            Name = name;
            Rank = rank;
            Coin = coin;
            this.Health = startHealth;
        }
        public bool SpendCoins(decimal amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Invalid coins");
                return false;
            }
            else if (Coin < amount)
            {
                Console.WriteLine("Insufficient coins to purchase");
                return false;
            }
            else
            {
                Coin -= amount;
                Console.WriteLine($"Successeful purchase! You have {Coin} left");
            }
            
            return true;
        }

        public decimal EarnCoins(decimal amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"{Name} has earned {amount}");
                Coin += amount;
            }
            Console.WriteLine($"Total coins: {Coin}");
            return Coin;
        }
        public virtual void Attack() //Abstraction
        {
            Console.WriteLine($"{Name} attacks");
        }
        public virtual void Dodge()
        {
            Console.WriteLine($"{Name} dodges attack");
        }
        public void Celebrate()
        {
            Console.WriteLine($"{Name} celebrates!");
        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage");

            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} has been defeated");
            }
        }
        public bool isAlive()
        {
            return Health > 0;
        }
    }
}
