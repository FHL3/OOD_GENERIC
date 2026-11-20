using OOD_Generics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public class Guild
    {
        public int GuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Character> CharacterList { get; set; }
        public Guild(int guid, string name, string description)
        {
            GuId = guid;
            Name = name;
            Description = description;
        }
    }
}
