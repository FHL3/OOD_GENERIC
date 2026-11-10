using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    class Character
    {
        public int ID {  get; set; }
        public string Name { get; set; }    
        public char Rank { get; set; }
        public double Coin { get; }
        public string Profession { get; set; }

        public Character(int id, string name, char rank, double coin, string prof)
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

    }
}
