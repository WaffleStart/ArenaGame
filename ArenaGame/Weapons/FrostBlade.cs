﻿using ArenaGame.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class FrostBlade : Weapon
    {
        int damageOnHit = 15;
        public FrostBlade() : base("FrostMourne")
        {
        }

        public override int Attack(int damage, Hero enemy)
        {

            AttackEffect(Status.Frozen, enemy, ref damageOnHit, damage);
            return base.Attack(damage, enemy);
        }
    }
}
