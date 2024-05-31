using ArenaGame.Weapons;
using System.Net.NetworkInformation;

namespace ArenaGame.Heroes
{
    public enum Status
    {
        Normal,
        Frozen,
        Burned,
        Stunned,
        Disarmed
    }
    public class Hero
    {
        private int chanceToLoseStatus = 40;
        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Strength { get; private set; }

        protected int StartingHealth { get; private set; }

        internal Status CurrentStatus { get; private set; } = Status.Normal; // cheat

        public bool IsDead { get { return Health <= 0; } }
        public bool IsDisarmed { get; private set; }= false;

        public virtual Weapon Weapon { get; private set; }

        public Hero(string name, Weapon weapon)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Weapon = weapon;
           
        }


        public virtual int Attack(Hero defender)
        {
            if (IsDisarmed || Weapon.IsBroken)
            {
                return Random.Shared.Next(80, 121);
            }
                return Weapon.Attack(Random.Shared.Next(80, 121), defender);
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            if (incomingDamage < 0) return;
            Health = Health - incomingDamage;
        }

        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }
        internal void ChangeStatus(Status newStatus)
        {
            CurrentStatus = newStatus;
            if (CurrentStatus == Status.Disarmed && IsDisarmed == false)
            {
                
                Console.WriteLine($"{Name} has been disarmed!");
                IsDisarmed = true;
                CurrentStatus = Status.Normal;
            }
            if (ThrowDice(chanceToLoseStatus) && CurrentStatus != Status.Normal && CurrentStatus != Status.Disarmed)
            {
                Console.WriteLine($"{Name} is no longer {CurrentStatus}!");
                CurrentStatus = Status.Normal;
            }
        }

        protected void Heal(int value)
        {
            Health = Health + value;
            if (Health > StartingHealth) Health = StartingHealth;
        }
    }
}
