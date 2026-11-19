using OOD_Generics;
using OOD_Generics.Models;
using OOD_Generics.Repositories;
using OOD_Generics.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;


List<Character> characters = new()
{
    new Warrior(1, "Selah", 'F', 100)
    {
        GuildId = 101,
        WeapId = 201
    },
    new Mage(2, "Elikai", 'F', 100)
    {
        GuildId = 102,
        WeapId = 203
    },
    new Rogue(3, "Shaddai", 'C', 100)
    {
        GuildId = 101
    },
    new Knight(4, "Elyon", 'E', 200)
    {
        WeapId = 202
    }
};
List<Guild> guilds = new()
{
    new Guild(101, "The Worshipful Company of Spectacle Makers", "A real-world medieval trade guild created to regulate the quality of eyeglasses and optical instruments"),
    new Guild(102, "The Cartographers of the Shifting Sands", "A secretive guild of desert navigators, astronomers, and mapmakers. Because the magical dunes of their homeland constantly reshape themselves overnight, this guild does not sell static maps."),
    new Guild(103, "The Guild of Saint Luke", "The most famous historical guild for painters, sculptors, and visual artists, named after Luke the Evangelist (the patron saint of artists)")
};

List<Weapon> weapons = new()
{
    new Weapon(201, "Whisperwind", "Carved from the pale, flexible branches of a lightning-struck silverleaf tree and strung with woven spider silk.", "Recurve Shortbow"),
    new Weapon(202, "The Peacemaker’s Gavel", "A massive, iron-bound warhammer whose head is forged from a single block of dense meteoric ore, engraved with scales of justice.", "Heavy Warhammer"),
    new Weapon(203, "Viper’s Kiss", "A slender, needle-thin blade crafted from blackened steel with a hollow groove running down the center.", "Stilleto Dagger")
};

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

Console.WriteLine("Here are your characters");
var allcharacters = from character in characters
            select character;
foreach (var name in allcharacters)
{
    CharacterView.DisplayCharacter(name);
}
Console.WriteLine();

characters.Add(new Mage(5, "Judah", 'A', 800));

Console.WriteLine("Finding Rank F characters in the List:");
//var findChar = characters.Where(x => x.Rank == 'F' && x.ID > 3).ToList(); //predicate
var rankFF = from character in characters
             where character.Rank == 'F'
             select character;

foreach (var name in rankFF)
{
    CharacterView.DisplayCharacter(name);
}

Console.WriteLine("Sorting characters from the List of names by their ID");
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

Console.WriteLine("Joining the characters with their Guild and Weapons");
var joinCharacterQuery = from character in characters
                         join guild in guilds
                         on character.GuildId equals guild.GuId
                         join weapon in weapons
                         on character.WeapId equals weapon.WeapId
                         select new
                         {
                             characterName = character.Name,
                             guildName = guild.Name,
                             weaponName = weapon.Name,
                         };
foreach (var Aquery in joinCharacterQuery)
{
    Console.WriteLine($"Character name: {Aquery.characterName} | {Aquery.guildName} | {Aquery.weaponName} ");
}

Console.WriteLine();
Console.WriteLine("===== ALL FIGHTERS =====");

ProcessCharacters(characters, c => CharacterView.DisplayCharacter(c));
Console.WriteLine();
Console.WriteLine("=== Training day ===");
ProcessCharacters(characters, c => c.Attack());
Console.WriteLine();
Console.WriteLine("===== Name of Character =====");
//Func
Func<Character, string> getTitle = c => $"{c.Name} the  {c.GetType().Name}";
Console.WriteLine(getTitle(characters[0]));
Console.WriteLine();
Console.WriteLine("The first fighters to grace us with their presence---ARE");
var arenaFighters = (from character in characters
                    select character).Take(2).ToList();
Character fighter1 = arenaFighters[0];
Character fighter2 = arenaFighters[1];


Console.WriteLine(fighter1.Name + " vs. " + fighter2.Name);
while(fighter1.isAlive() && fighter2.isAlive())
{
    fighter1.Attack();
    fighter2.TakeDamage(fighter1.Damage);

    Console.WriteLine($"{fighter2.Name} HP: {fighter2.Health}");


    if (!fighter2.isAlive())
    {
        Console.WriteLine();
        Console.WriteLine($"{fighter1.Name} WINS");
        break;
    }
    Console.WriteLine();

    fighter2.Attack();
    fighter1.TakeDamage(fighter2.Damage);

    Console.WriteLine($"{fighter1.Name} HP: {fighter1.Health}");
    if (!fighter1.isAlive())
    {
        Console.WriteLine();
        Console.WriteLine($"{fighter2.Name} WINS");
        break;
    }
    Console.WriteLine();
}
Console.ReadLine();