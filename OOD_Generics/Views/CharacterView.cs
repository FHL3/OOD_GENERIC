using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Generics.Models;

namespace OOD_Generics.Views
{
    public static class CharacterView
    {
        public static void DisplayCharacter(Character character)
        {
            Console.WriteLine($"{character.ID} | {character.Name} | {character.Rank} | {character.Health}[---]");
        }
        public static void DisplayCharacters(IEnumerable<Character> characters)
        {
            foreach(Character character in characters)
            {
                DisplayCharacter(character);
            }
        }
    }
}
