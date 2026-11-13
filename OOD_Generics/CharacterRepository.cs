using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public class CharacterRepository : ICharacterRepository
    {
        private List<Character> characters = new();
        public void Add(Character character)
        {
            characters.Add(character);
        }
        public IEnumerable<Character> GetAll()
        {
            return characters.ToList();
        }

        public Character GetById(int id)
        {
            return characters.Where(p => p.ID == id).FirstOrDefault(); //predicate function
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
        public void Remove(int id)
        {
            Character character1 = GetById(id);
            if (character1 != null) 
            {
                characters.Remove(character1);
            }
        }

        public void AddCharacter(Character character)
        {
            characters.Add(character);
        }
    }
}
