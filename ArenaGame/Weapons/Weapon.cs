using ArenaGame.Heroes;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace ArenaGame.Weapons
{
    //enum UniqueEffect // old effects when weapon was one single class. Remember for later to very loosely base around.
    //{
    //    Shock, //Making use of the status effects i just made for the avatar, shock causes more damage. // hammer, kinda like Thor
    //    Siphon, // steal hp // Scythe, because it's a cool weapon
    //    TemporalDisruption, // stuns // Chronoblade
    //    VenomousSting // poison aka burn, one in the same. // Has to be a dagger obviously
    //}
    //Frozen,
    //    Burned,
    //    Stunned,
    //    Disarmed
  
    public enum State
    {
        Flawless,
        Damaged,
        Broken
    }
    abstract public class Weapon
    {

        protected Weapon(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        protected State CurrentState { get; set; } = State.Flawless;
        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            if (ThrowDice(1))
            {
                CurrentState = State.Broken; // why not

            }
            return dice <= chance;
        }

        protected void AttackEffect(Status status, Hero enemy, int damageOnHit, int damage)
        {
            if (ThrowDice(10))
            {
               enemy.ChangeStatus(status);
                if (ThrowDice(10))
                {
                    CurrentState = State.Damaged; // less damage only
                    damageOnHit = damage -= Random.Shared.Next(1, 16);
                }

            }
        }
        public virtual int Attack(int damage, Hero enemy) => damage;
    }
}
