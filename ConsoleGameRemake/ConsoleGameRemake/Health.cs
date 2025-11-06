namespace ConsoleGameRemake
{
    public class Health : IDamageable
    {
        private int _value;

        public int Value
        {
            get => _value;

            protected set
            {
                _value = value > 0 ? value : 0;
            }
        }

        public bool IsArmored { get; set; }

        public Health(int hp)
        {
            _value = hp >= 0
                ? hp
                : throw new ArgumentException($"Hp can't be negative {hp}", nameof(hp));
        }

        public virtual void TakeDamage(int damage)
        {
            Value -= Math.Max(0, damage);
        }
    }
}
