using ArenaGame.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Hammer : Weapon
    {
       
        private int damageOnHit = 15; // currently low dmg cause stun is op.
        public Hammer() : base("Mjölnir")
        {
        }

        public override int Attack(int damage, Hero enemy)
        {
            AttackEffect(Status.Stunned, enemy, ref damageOnHit, damage);
            return damage + damageOnHit;
        }
    }
}
