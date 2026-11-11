using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Generics
{
    interface ICharacterRepository
    {
        void addCharacter(Character character);
        Character getCharacterById(int characterId);
        void updateCharacter(Character updateCharacter);
        void removeCharacter(int characterId);
    }
}
