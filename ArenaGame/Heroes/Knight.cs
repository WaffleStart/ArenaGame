using ArenaGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Knight : Hero
    {
        const int BlockDamageChance = 10;
        private const int ExtraDamageChance = 5;
        Weapon wep;
        public Knight(Weapon weapon) : base("Sir John", weapon)
        {
            wep = weapon;
        }

    

        public override void TakeDamage(int incomingDamage)
        {
            //Apply armor
            int damageReduceCoef = Random.Shared.Next(20, 61);
            incomingDamage =
                incomingDamage - incomingDamage * damageReduceCoef / 100;
            //Apply special skill: block
            if (ThrowDice(BlockDamageChance)) incomingDamage = 0;
            //Default behavior
            base.TakeDamage(incomingDamage);
        }

        public override int Attack(Hero defender)
        {
            int attack = base.Attack(defender);
            if (ThrowDice(ExtraDamageChance)) attack = attack * 150 / 100;
            return wep.Attack(attack,defender);
        }
    }
}
