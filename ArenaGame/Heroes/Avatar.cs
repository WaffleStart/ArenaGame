using ArenaGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Avatar : Hero // Who doesn't love Aang.
    {
        private bool hasAlreadyBeenDisarmed = false;
        private int chanceToApplyStatus = 45; // balancing classes sucks.
     

       
        public Avatar(Weapon weapon) : base("Aang", weapon)
        {
        }
        public Status StatusEffect()
        {
            if (ThrowDice(25))
            {
                //Water freezes enemy, skips enemy turn.

                return Status.Frozen;
            }
            else if (ThrowDice(50) && !hasAlreadyBeenDisarmed)
            {
                //Air gets rid of opponents weapon
                hasAlreadyBeenDisarmed = true;
                return Status.Disarmed;

            }
            else if (ThrowDice(75))
            {
                //Fire causes a small amount of damage each turn

                return Status.Burned;
            }
            else
            {
                //Earth stuns enemy, skips enemy turn.
                return Status.Stunned;

            }

        }
        public override int Attack(Hero defender)
        { // each attack excluding air will have a chance to be removed each turn, burn being the lowest

            if (ThrowDice(chanceToApplyStatus) && defender.CurrentStatus == Status.Normal) // 90% seems insane, but lancelot is even more insane goddamn, Had to bump it to 90 just to stand a chance
                                                                                           //Remember to change after Weapon implementation as this will be far too Op then.
            {
                defender.ChangeStatus(StatusEffect());
            }
            int attack = base.Attack(defender);
            if (defender.CurrentStatus == Status.Burned)
            {
                attack += Random.Shared.Next(0, 301);
            }
           
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {

            base.TakeDamage(incomingDamage);
        }
    }
}
