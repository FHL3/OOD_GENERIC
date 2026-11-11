using OOD_Generics;

//Generic List<T>
List<Character> characters = new()
{
    new Warrior(1, "Selah", 'F', 100),
    new Mage(2, "Elikai", 'F', 100),
    new Rogue(3, "Shaddai", 'F', 100),

};

foreach (Character character in characters)
{
    character.CharacterInfo();
    character.Attack();
}

