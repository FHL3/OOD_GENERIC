using OOD_Generics;
using System.Collections.Generic;



Console.WriteLine("Welcome to Aetheria Arena");
Console.WriteLine("Where you can fight and become King of the Arena");
Console.WriteLine();
Console.WriteLine("=====CHOOSE YOUR FIGHTER=====");
//Generic List<T>
List<Character> characters = new()
{
    new Warrior(1, "Selah", 'F', 100),
    new Mage(2, "Elikai", 'F', 100),
    new Rogue(3, "Shaddai", 'F', 100),
    new Knight(4, "Elyon", 'E', 200)
};
int fighterNumber = 1;
foreach (Character character in characters)
{
    Console.WriteLine($"{fighterNumber}. {character.Name} | {character.GetType().Name} | Rank {character.Rank} | Coins {character.Coin}");
    fighterNumber++;
}
Console.WriteLine();
Console.WriteLine("Choose a fighter: ");
int choice = Convert.ToInt32(Console.ReadLine());

Character selectedFighter = characters[choice - 1];
Console.WriteLine();
Console.WriteLine($"You selected {selectedFighter.Name}!");
Console.WriteLine();
Console.WriteLine("Choose a 2nd fighter: ");
int choice2 = Convert.ToInt32(Console.ReadLine());

Character selectedFighter2 = characters[choice2 - 1];
Console.WriteLine();
Console.WriteLine($"You selected {selectedFighter2.Name}!");

Console.WriteLine("====Now FIGHT====");
Console.WriteLine($"{selectedFighter.Name} VS {selectedFighter2.Name}");
selectedFighter.Attack();
Console.WriteLine();
selectedFighter2.Attack();

//Action<Character> action;
//Action celebrate = () => Console.WriteLine($"{selectedFighter.Name}");

foreach (CharacterRepository character in characters)
{
    yield return character;
}