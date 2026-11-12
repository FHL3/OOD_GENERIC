using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public class Character
    {
        public int ID {  get;}
        public string Name { get; set; }    
        public char Rank { get; set; }
        public decimal Coin { get; private set; } //encapsulation

        public Character(int id, string name, char rank, decimal coin)
        {
            ID = id;
            Name = name;
            Rank = rank;
            Coin = coin;
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
                Console.WriteLine($"You have earned {amount}");
                Coin += amount;
            }
            Console.WriteLine($"Total coins: {Coin}");
            return Coin;
        }
        public virtual void Attack() //Abstraction
        {
            Console.WriteLine($"{Name} attacks");
        }

        public void CharacterInfo()
        {
            Console.WriteLine($"Name: {Name}, Rank: {Rank}, Coins: {Coin}.");
        }
    }
}
