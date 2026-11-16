using OOD_Generics;
using System.Collections.Generic;
using System.ComponentModel;

using OOD_Generics;
using System.Reflection.Metadata.Ecma335;

static void ProcessCharacters(
    IEnumerable<Character> characters,
    Action<Character> action)
{
    foreach (Character character in characters)
    {
        action(character);
    }
}

Console.WriteLine("Welcome to Aetheria Arena");
Console.WriteLine("Where you can fight and become King of the Arena");
Console.WriteLine();

List<Character> characters = new()
{
    new Warrior(1, "Selah", 'F', 100),
    new Mage(2, "Elikai", 'F', 100),
    new Rogue(3, "Shaddai", 'F', 100),
    new Knight(4, "Elyon", 'E', 200)
};

Console.WriteLine("===== ALL FIGHTERS =====");

ProcessCharacters(
    characters,
    c => c.CharacterInfo()
);

Console.WriteLine();
Console.WriteLine("=== Training day ===");
ProcessCharacters(characters, c => c.Attack());
Console.WriteLine();
Console.WriteLine("===== Name of Charcater =====");
//Func
Func<Character, string> getTitle = c => $"{c.Name} the  {c.GetType().Name}";
Console.WriteLine(getTitle(characters[0]));
Console.WriteLine();
Console.WriteLine("Demostrating Repository");
var characterRepository = new CharacterRepository();
characterRepository.AddCharacter(new Character(2, "Seke", 'E', 200));
characterRepository.AddCharacter(new Character(3, "Aris", 'F', 600));

foreach (Character character in characterRepository.GetAll())
{
    character.CharacterInfo();
}