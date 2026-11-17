using OOD_Generics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

static void ProcessCharacters(IEnumerable<Character> characters, Action<Character> action)
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

Console.WriteLine("Transforming character into string");
var names = characters.Select(x => x.Name);
foreach(string name in names)
{
    Console.WriteLine(name);
}
Console.WriteLine();
characters.Add(new Mage(5, "Judah", 'A', 800));

Console.WriteLine("Finding Rank F characters in the List");
var findChar = characters.Where(x => x.Rank == 'F').ToList(); //predicate
foreach(var character in findChar)
{
    Console.WriteLine(character.Name);
}
Console.WriteLine();

Console.WriteLine("Sorting characters from the List of names");
var sorted = characters.OrderByDescending(x => x.ID).ToList();

foreach (var character in sorted)
{
    Console.WriteLine(character.Name);
}
Console.WriteLine();
Console.WriteLine("Use of SelectMany method");
var charQuery = from character in characters
                from word in character.Name
                select word;

foreach(char character in charQuery)
{
    Console.WriteLine(character);
}

Console.WriteLine();
Console.WriteLine("Group characters by Rank");
var groupCharacters = characters.GroupBy(r => r.Rank);

foreach (var group in groupCharacters)
{
    Console.WriteLine($"Rank {group.Key}");
    foreach (var character in group)
    {
        Console.WriteLine($" - {character.Name}");
    }
}
Console.WriteLine();
Console.WriteLine("===== ALL FIGHTERS =====");

ProcessCharacters(characters,c => c.CharacterInfo()
);

Console.WriteLine();
Console.WriteLine("=== Training day ===");
ProcessCharacters(characters, c => c.Attack());
Console.WriteLine();
Console.WriteLine("==== Earn Coins ====");
ProcessCharacters(characters, e => e.EarnCoins(499));
Console.WriteLine();
Console.WriteLine("===== Name of Charcater =====");
//Func
Func<Character, string> getTitle = c => $"{c.Name} the  {c.GetType().Name}";
Console.WriteLine(getTitle(characters[0]));
Console.WriteLine();
Console.WriteLine("Demostrating Repository");
var characterRepository = new CharacterRepository();
characterRepository.AddCharacter(new Character(1, "Seke", 'E', 200));
characterRepository.AddCharacter(new Character(2, "Aris", 'C', 450));
characterRepository.AddCharacter(new Character(3, "Kirito", 'B', 600));

foreach (var character in characterRepository.GetAll())
{
    character.CharacterInfo();
}
Console.WriteLine();
var charactNamerepo = characterRepository.GetAll().Where(x => x.Name == "Seke");
foreach (var character in charactNamerepo)
{
    character.CharacterInfo();
}