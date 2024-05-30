using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Summoner : Hero
    {
        int createdMinions = Random.Shared.Next(10, 31);
        public Summoner() : this("Dumbledore")
        {

        }
        public Summoner(string name) : base(name)
        {
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (ThrowDice(15))
            {
                Console.WriteLine("MR. PRESIDENT GET DOWN!");
                Console.WriteLine($"Ally has taken the hit for {Name} and perished.");
                createdMinions--;
                base.TakeDamage(0);
            }
            else
            {
                base.TakeDamage(incomingDamage);
            }

        }

        public override int Attack(Hero defender)
        {
            int attack = base.Attack(defender); // Let us say this is 100 dmg. 

            for (int i = 0; i < createdMinions; i++) // let us say 30 minions
            {
                if (ThrowDice(5)) // Enrage a minion
                {
                    attack += base.Attack(defender) / 3; // this would make it 33 damage at best.
                    continue;
                }
                attack += base.Attack(defender) / 50; // this would make it 2 damage at best
            }
            return attack; // this would be 100+66+30;
        }
    }
}
