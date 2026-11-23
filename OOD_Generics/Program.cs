using OOD_Generics;
using OOD_Generics.Models;
using OOD_Generics.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

static void ProcessCharacters(IEnumerable<Character> characters, Action<Character> action)
{
    foreach (Character character in characters)
    {
        action(character);
    }
}
static List<string> LoadCharacters() //Sync
{
    Console.WriteLine("Reading file...");
    try
    {
        Console.WriteLine("Loading characters...");

        var fileContent = File.ReadAllLines("C:\\Users\\FHLEBAN\\source\\repos\\OOD_Generics\\OOD_Generics\\Data\\character.txt").ToList();

        return fileContent;
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Could not find file");
    }
    catch (IOException)
    {
        Console.WriteLine($"File error");
    }
    catch (Exception)
    {
        Console.WriteLine($"An unexpected error occurred");
    }
    return new List<string>();
}
static async Task<List<string>> LoadCharactersAsync()
{
    Console.WriteLine("Reading file...");
    try
    {
        Console.WriteLine("Loading characters...");
        var fileContent = await File.ReadAllLinesAsync("C:\\Users\\FHLEBAN\\source\\repos\\OOD_Generics\\OOD_Generics\\Data\\character.txt");
        return fileContent.ToList();
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Could not find file");
    }
    catch (IOException)
    {
        Console.WriteLine($"File error");
    }
    catch (Exception)
    {
        Console.WriteLine($"An unexpected error occurred");
        
    }
    return new List<string>();
}
static async Task<string[]> ReadFileAsync(string filepath, SemaphoreSlim semaphore, CancellationToken token)
{
    await semaphore.WaitAsync(token);
    token.ThrowIfCancellationRequested();
    try
    {
        Console.WriteLine($"Reading: {Path.GetFileName(filepath)}");
        await Task.Delay(5000, token);
        string[] content = await File.ReadAllLinesAsync(filepath, token);
        Console.WriteLine($"Finished: {Path.GetFileName(filepath)}");
        return content;
    }
    finally
    {
        semaphore.Release();
    }
}

Console.WriteLine("===== SYNC FILE LOAD =====");
var characterLines = LoadCharacters();
foreach (var line in characterLines)
{
    Console.WriteLine(line);
}
Console.WriteLine("===== Async file load =====");
var asyncCharacterLines = await LoadCharactersAsync();
foreach (var line in asyncCharacterLines)
{
    Console.WriteLine(line);
}
Console.WriteLine();
Console.WriteLine("First Section without SemaphoreSlim");
Console.WriteLine("Loading multiple files");

var characterTask = File.ReadAllLinesAsync(@"C:\\Users\\FHLEBAN\\source\\repos\\OOD_Generics\\OOD_Generics\\Data\\character.txt");

var guildsTask = File.ReadAllLinesAsync(@"C:\\Users\\FHLEBAN\\source\\repos\\OOD_Generics\\OOD_Generics\\Data\\guilds.txt");

var weaponTask = File.ReadAllLinesAsync(@"C:\\Users\\FHLEBAN\\source\\repos\\OOD_Generics\\OOD_Generics\\Data\\weapons.txt");
try
{
  await Task.WhenAll(characterTask, guildsTask, weaponTask);

} catch (OperationCanceledException)
{
    Console.WriteLine("Operation has been cancelled.");
}


string[] player = await characterTask;
string[] team = await guildsTask;
string[] equip = await weaponTask;

Console.WriteLine("Files loaded.");

Console.WriteLine("Second section: With SepmaphoreSlim");
string dataPath = @"C:\Users\FHLEBAN\source\repos\OOD_Generics\OOD_Generics\Data";

using SemaphoreSlim semaphore = new SemaphoreSlim(2, 2);
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

string characterFile = Path.Combine(dataPath, "character.txt");
string guildFile = Path.Combine(dataPath, "guilds.txt");
string weaponFile = Path.Combine(dataPath, "weapons.txt");

Console.WriteLine("Loading multiple files...");

cts.CancelAfter(1000);

Task<string[]> charactTask = ReadFileAsync(characterFile, semaphore, token);
Task<string[]> guildTask = ReadFileAsync(guildFile, semaphore, token);
Task<string[]> weapTask = ReadFileAsync(weaponFile, semaphore, token);

await Task.WhenAll(charactTask, guildTask, weapTask);


string[] chrcters = await charactTask;
string[] org = await guildTask;
string[] weapo = await weapTask;

Console.WriteLine($"Characters loaded: {chrcters.Length}");
Console.WriteLine($"Guilds loaded: {org.Length}");
Console.WriteLine($"Weapons loaded: {weapo.Length}");

Console.WriteLine();
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
        WeapId = 204
    },
    new Rogue(3, "Shaddai", 'C', 100)
    {
        GuildId = 103,
        WeapId = 203
    },
    new Knight(4, "Elyon", 'E', 200)
    {
        GuildId = 104,
        WeapId = 202
    }
};
List<Guild> guilds = new()
{
    new Guild(101, "The Worshipful Company of Spectacle Makers", "A real-world medieval trade guild created to regulate the quality of eyeglasses and optical instruments"),
    new Guild(102, "The Cartographers of the Shifting Sands", "A secretive guild of desert navigators, astronomers, and mapmakers. Because the magical dunes of their homeland constantly reshape themselves overnight, this guild does not sell static maps."),
    new Guild(103, "The Guild of Saint Luke", "The most famous historical guild for painters, sculptors, and visual artists, named after Luke the Evangelist (the patron saint of artists)"),
    new Guild(104, "The DrakenSbane of Areth", "A group of lizardman who navigate through the desert looking and searching for magical equipment")
};

List<Weapon> weapons = new()
{
    new Weapon(201, "Whisperwind", "Carved from the pale, flexible branches of a lightning-struck silverleaf tree and strung with woven spider silk.", "Recurve Shortbow"),
    new Weapon(202, "The Peacemaker’s Gavel", "A massive, iron-bound warhammer whose head is forged from a single block of dense meteoric ore, engraved with scales of justice.", "Heavy Warhammer"),
    new Weapon(203, "Viper’s Kiss", "A slender, needle-thin blade crafted from blackened steel with a hollow groove running down the center.", "Stilleto Dagger"),
    new Weapon(204, "Staff of Wisdom", "Carved from the last known tree in existance, a tall and long magical staff said to have it's root connected to the Earth's core", "Magic Staff")
};
List<string> titles = new()
{
    "The brave Warrior of the sea",
    "The king of Noodles",
    "Orange Leander"
};
Console.WriteLine();
Console.WriteLine(" ===== LINQ Queries ===== ");

Console.WriteLine("Introducing your characters");
var allcharacters = from character in characters
                    select character;
foreach (var name in allcharacters)
{
    CharacterView.DisplayCharacter(name);
}
Console.WriteLine();

characters.Add(new Mage(5, "Judah", 'A', 800));
Console.WriteLine("Order of Rank in an ascending order");
var rankOrder = from character in characters
                orderby character.Rank
                select character;
foreach (var name in rankOrder)
{
    CharacterView.DisplayCharacter(name);
}
Console.WriteLine();
Console.WriteLine("Finding Specific Character with ID = 3");
//var findChar = characters.Where(x => x.Rank == 'F' && x.ID > 3).ToList(); //predicate
var rankFF = from character in characters
             where character.ID == 3
             select character;

foreach (var name in rankFF)
{
    CharacterView.DisplayCharacter(name);
}
Console.WriteLine();
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

Console.WriteLine("Zip: Let's give our characters tiles");
var results = from pair in characters.Zip(titles)
              select $"{pair.First.Name} - {pair.Second}";
foreach (var pair in results)
{
    Console.WriteLine(pair);
}
Console.WriteLine();
Console.WriteLine("===== ALL FIGHTERS =====");

ProcessCharacters(characters, c => CharacterView.DisplayCharacter(c));
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

//Sync
//Console.WriteLine(fighter1.Name + " vs. " + fighter2.Name);
//while (fighter1.isAlive() && fighter2.isAlive())
//{
//    fighter1.Attack();
//    fighter2.TakeDamage(fighter1.Damage);

//    Console.WriteLine($"{fighter2.Name} HP: {fighter2.Health}");


//    if (!fighter2.isAlive())
//    {
//        Console.WriteLine();
//        Console.WriteLine($"{fighter1.Name} WINS");
//        break;
//    }
//    Console.WriteLine();

//    fighter2.Attack();
//    fighter1.TakeDamage(fighter2.Damage);

//    Console.WriteLine($"{fighter1.Name} HP: {fighter1.Health}");
//    if (!fighter1.isAlive())
//    {
//        Console.WriteLine();
//        Console.WriteLine($"{fighter2.Name} WINS");
//        break;
//    }
//    Console.WriteLine();
//}
//Async
Console.WriteLine("[===FIGHT===]");
Console.WriteLine(fighter1.Name + " vs. " + fighter2.Name);
while (fighter1.isAlive() && fighter2.isAlive())
{
    Console.WriteLine();
    await fighter1.AttackAsync();
    if (fighter2.TryDodge())
    {
        await fighter2.DodgeAsync();
    }
    else
    {
        fighter2.TakeDamage(fighter1.Damage);
    }
    Console.WriteLine($"{fighter2.Name} HP: {fighter2.Health}");


    if (!fighter2.isAlive())
    {
        Console.WriteLine();
        Console.WriteLine($"{fighter1.Name} WINS");
        fighter1.Celebrate();
        break;
    }

    Console.WriteLine();
    await fighter2.AttackAsync();
    if (fighter1.TryDodge())
    {
        await fighter1.DodgeAsync();
    }
    else
    {
        fighter1.TakeDamage(fighter2.Damage);
    }

    Console.WriteLine($"{fighter1.Name} HP: {fighter1.Health}");
    if (!fighter1.isAlive())
    {
        Console.WriteLine();
        Console.WriteLine($"{fighter2.Name} WINS");
        fighter2.Celebrate();
        break;
    }
    Console.WriteLine();
}
Console.ReadLine();