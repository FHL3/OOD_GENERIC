using OOD_Generics;
using OOD_Generics.Models;
using OOD_Generics.Repositories;
using OOD_Generics.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

static void ProcessCharacters(IEnumerable<Character> characters, Action<Character> action)
{
    foreach (Character character in characters)
    {
        action(character);
    }
}

Console.WriteLine("=====Welcome to Aetheria Arena=====");
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
var names = from character in characters
            select character;
foreach (var name in names)
{
    CharacterView.DisplayCharacter(name);
}
Console.WriteLine();

characters.Add(new Mage(5, "Judah", 'A', 800));

Console.WriteLine("Finding Rank F characters in the List");
//var findChar = characters.Where(x => x.Rank == 'F' && x.ID > 3).ToList(); //predicate
var rankFF = from character in characters
             where character.Rank == 'F'
             select character;

foreach (var name in rankFF)
{
    CharacterView.DisplayCharacter(name);
}

Console.WriteLine("Sorting characters from the List of names");
//var sorted = characters.OrderByDescending(x => x.ID).ToList();
var srted = from character in characters
            orderby character.ID
            select character;
foreach (var character in srted)
{
    CharacterView.DisplayCharacter(character);
}

Console.WriteLine();
Console.WriteLine("Group characters by Rank");
//var groupCharacters = characters.GroupBy(r => r.Rank);
var groupCharacters = from character in characters
                      group character by character.Rank into characterGroup
                      select characterGroup;

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

ProcessCharacters(characters, c => CharacterView.DisplayCharacter(c));

Console.WriteLine();
Console.WriteLine("=== Training day ===");
ProcessCharacters(characters, c => c.Attack());
Console.WriteLine();
Console.WriteLine("==== Earn Coins ====");
ProcessCharacters(characters, e => e.EarnCoins(45));
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
characterRepository.AddCharacter(new Mage(4, "Ebednego", 'F', 300));
characterRepository.AddCharacter(new Knight(5, "Peter", 'F', 300));

CharacterView.DisplayCharacters(characterRepository.GetAll());

Console.WriteLine();
var charactNamerepo = characterRepository.GetAll().Where(x => x.Name == "Seke");

foreach (var character in charactNamerepo)
{
    CharacterView.DisplayCharacter(character);
}
Console.WriteLine();
Console.WriteLine("=======IQueryable========");
var query = characterRepository.Query(); //Collection that supports qury building
query = characterRepository.Query().Where(c => c.Rank == 'F');
foreach(var character in query)
{
    //character.
}

var queryName = characterRepository.Query().Select(s => s.Name);
foreach(string name in queryName)
{
    Console.Write("Character:");
    Console.WriteLine(name);
}

var queryOrder = characterRepository.Query().OrderByDescending(o => o.Rank);

Console.ReadLine();