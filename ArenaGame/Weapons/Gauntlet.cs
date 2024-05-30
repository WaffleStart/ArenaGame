using ArenaGame.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Gauntlet : Weapon
    {
        
        private int damageOnHit = 25; // high damage as it is gauntlets, aka both hands strike (that and burn is incredibly weak)
        public Gauntlet() : base("Ignis")
        {
        }

        public override int Attack(int damage, Hero enemy)
        {

            AttackEffect(Status.Burned, enemy, damageOnHit, damage);
            return base.Attack(damage, enemy);
        }
    }
}
