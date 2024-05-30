using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

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

            for (int i = 0; i < rounds; i++)
            {
                Weapon firstWep = weapons[Random.Shared.Next(0, 4)];
                Weapon secondWep = weapons[Random.Shared.Next(0, 4)];
                Hero one = new Knight(firstWep);
                //Hero one = new Rogue(firstWep);
                Hero two = new Avatar(secondWep);
                //Hero two = new Summoner(secondWep);
                Console.WriteLine($"{one.Name} with legendary weapon {firstWep.Name} is fighting {two.Name}, who is using the legendary {secondWep.Name}");
                Console.WriteLine($"Arena fight between: {one.Name} and {two.Name}");
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


    }
}
