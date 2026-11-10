using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    class Character
    {
        public int ID {  get;}
        public string Name { get; set; }    
        public char Rank { get; set; }
        public decimal Coin { get; private set; } //encapsulation
        public string Profession { get; set; }

        public Character(int id, string name, char rank, decimal coin, string prof)
        {
            ID = id;
            Name = name;
            Rank = rank;
            Coin = coin;
            Profession = prof;
        }
        public void CharacterInfo()
        {
            Console.WriteLine($"Name: {Name}, Rank: {Rank}, Coins: {Coin}, Profession: {Profession}");
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
    }
}
