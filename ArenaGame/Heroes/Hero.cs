using ArenaGame.Weapons;

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
        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Strength { get; private set; }

        protected int StartingHealth { get; private set; }

        internal Status CurrentStatus { get; private set; } = Status.Normal; // cheat

        public bool IsDead { get { return Health <= 0; } }

        public Weapon Weapon { get; private set; }

        public Hero(string name, Weapon weapon)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
           
        }

        public Hero(string v)
        {
        }

        public virtual int Attack(Hero defender)
        {
            return Random.Shared.Next(80, 121);
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
        }

        protected void Heal(int value)
        {
            Health = Health + value;
            if (Health > StartingHealth) Health = StartingHealth;
        }
    }
}
