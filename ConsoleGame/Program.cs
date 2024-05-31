using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Weapon> weapons = new()
            {
               new Dagger(),
               new Gauntlet(),
               new FrostBlade(),
               new Hammer()

            };
            Console.Write("Enter number of battles:");
            int rounds = Int32.Parse(Console.ReadLine());

            int oneWins = 0, twoWins = 0;

            Console.WriteLine("Which two characters would you like to see fight to the death?");
            Console.WriteLine("Available choices are: Knight, Avatar, Rogue and Summoner. You must choose two in total!");
            Console.WriteLine("Please note if you do not write the full name or the first letter it will not work, so pretty please do not crash my program :)");
            string[] characters = CharacterCreation();
        
            for (int i = 0; i < rounds; i++)
            {
                Weapon firstWep = weapons[Random.Shared.Next(0, 4)];
                Weapon secondWep = weapons[Random.Shared.Next(0, 4)];
                //Weapon firstWep = weapons[0];
                //Weapon secondWep = weapons[1];
                Assembly assembly = Assembly.LoadFrom(@"../../../../ArenaGame\bin\Debug\net8.0/ArenaGame.dll"); // why did i do this..
                string fullName = $"ArenaGame.Heroes.{characters[0]}";
                Type type1 = assembly.GetType(fullName);
                fullName = $"ArenaGame.Heroes.{characters[1]}";
                Type type2 = assembly.GetType(fullName);
                
                Hero one = Activator.CreateInstance(type1, new object[] { firstWep }) as Hero;
                Hero two = Activator.CreateInstance(type2, new object[] { secondWep }) as Hero;


                //Hero one = new Rogue(firstWep);
                //Hero two = new Summoner(secondWep);
                Console.WriteLine($"{one.Name} with legendary weapon {firstWep.Name} is fighting {two.Name}, who is using the legendary {secondWep.Name}");
               
                Arena arena = new(one, two);
                Hero winner = arena.Battle();
                Console.WriteLine($"Winner is: {winner.Name}");
                if (winner == one) oneWins++; else twoWins++;
            }
            Console.WriteLine();
            Console.WriteLine($"One has {oneWins} wins.");
            Console.WriteLine($"Two has {twoWins} wins.");

            Console.ReadLine();
        }

        private static string[] CharacterCreation()
        {
            string[] heroes = new string[2];
            int index = 0;
            while (index < 2)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "knight":
                    case "k":
                        heroes[index] = "Knight";
                        break;
                    case "avatar":
                    case "a":
                        heroes[index] = "Avatar";
                        break;
                    case "rogue":
                    case "r":
                        heroes[index] = "Rogue";
                        break;
                    case "summoner":
                    case "s":
                        heroes[index] = "Summoner";
                        break;
                    default:
                        continue;
                }
                index++;
            }
            return heroes;
        }
    }
}
