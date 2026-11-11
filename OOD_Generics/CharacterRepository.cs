using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    public class CharacterRepository : IRepository<Character>
    {
        private List<Character> characters = new List<Character>();
        public IEnumerable<Character> GetAll()
        {

        }

        public Character GetById(int id)
        {

        }
        public void Add(Character character)
        {

        }
        public void Update(Character character)
        {

        }
        public void Remove(int  id)
        {

        }
    }
}
