using OOD_Generics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics.Repositories
{
    public interface ICharacterRepository : IRepository<Character>
    {
        void AddCharacter(Character character); 
    }
}
