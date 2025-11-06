namespace ConsoleGameRemake
{
    public abstract class Monster : IDamageable
    {
        private Health _health;

        public int Hp => _health.Value;

        public Health HealthComponent
        {
            get => _health;

            set => _health = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Name { get; set; }

        protected Monster(int hp, string name = "Noname")
            : this(new Health(hp), name) { }

        protected Monster(Health health, string name = "Noname")
        {
            Name = name;
            HealthComponent = health;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}
