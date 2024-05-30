using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace ArenaGame
{
    public class Arena
    {

       
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }
        
        public Arena(Hero a, Hero b)
        {
            
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;
            if (Random.Shared.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }
            while (true)
            {
                int damage = attacker.Attack(defender);
                defender.TakeDamage(damage);
                Console.WriteLine($"{attacker.Name} has dealt {damage} damage to {defender.Name}");
                if (defender.IsDead) return attacker;
                //Swap the heroes
                if (defender.CurrentStatus == Status.Frozen || defender.CurrentStatus == Status.Stunned)
                {
                    Console.WriteLine($"{defender.Name} is frozen/stunned, skipping turn");
                    continue;
                }

                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }
}
