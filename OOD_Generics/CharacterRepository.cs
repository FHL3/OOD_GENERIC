using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public class CharacterRepository : IRepository<Character>
    {
        private List<Character> characters = new();
        public IEnumerable<Character> GetAll()
        {
            return characters;
        }

        public Character GetById(int id)
        {
           foreach(Character character in characters)
            {
                if (character.ID == id)
                {
                    return character;
                }

            }

            Console.WriteLine("test message");
            return null;
        }
        public void Add(Character character)
        {
            characters.Add(character);
        }
        public void Update(Character character)
        {
            Character existingCharacter = GetById(character.ID);

            if (existingCharacter != null)
            {
                existingCharacter.Name = character.Name;
                existingCharacter.Rank = character.Rank;
            }
        }
        public void Remove(int  id)
        {
            Character character1 = GetById(id);
            if (character1 != null) 
            {
                characters.Remove(character1);
            }
        }
    }
}
