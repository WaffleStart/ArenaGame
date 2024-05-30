using ArenaGame.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Dagger : Weapon
    {
        int damageOnHit = 20;
        public Dagger() : base("Nightingale's Fang")
        {
        }

        public override int Attack(int damage, Hero enemy)
        {

            AttackEffect(Status.Disarmed, enemy, damageOnHit, damage); // Potentially the strongest
            return base.Attack(damage, enemy);
        }
    }
}
