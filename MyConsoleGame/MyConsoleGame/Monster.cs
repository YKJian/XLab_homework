#nullable disable

namespace MyConsoleGame
{
    internal class Monster
    {
        private int _health; 

        public int Health 
        { 
            get => _health; 
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else
                {
                    _health = value;
                }
            } 
        }

        public string ClassType { get; init; }

        public string Name { get; init; }

        public string FullName => $"{ClassType} {Name}";

        protected float _receivedDamageCoefficient = 1f;
        protected float _dodgeDamageChance = 0f;
        public Random random = new Random();
        public event Action<Monster> Eliminate;

        public Monster(int health)
        {
            Health = health;
            ClassType = this.GetType().Name;
            Console.Write("Enter monster's name: ");
            Name = Console.ReadLine();
        }

        public virtual void TakeDamage(int damage)
        {
            int randomValue = random.Next(1, 101);

            if (randomValue > _dodgeDamageChance * 100)
            {
                int receivedDamage = (int)(damage * _receivedDamageCoefficient);
                Health -= receivedDamage;
                Console.WriteLine($"{FullName} received {receivedDamage} damage, current HP: {Health}");

                if (Health <= 0) 
                {
                    Die();
                }
            }
            else
            {
                Console.WriteLine($"{FullName} dodged the attack");
            }
        }

        public virtual void Move()
        {
            Console.WriteLine($"{FullName}'s type of movement: default");
        }

        public virtual void GetUpgraded() 
        {
            Console.WriteLine($"{FullName} got upgraded");
        }

        public virtual void Die()
        {
            Console.WriteLine($"{FullName} died");
            Eliminate?.Invoke(this);
        }
    }
}
