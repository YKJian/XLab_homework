namespace ConsoleGameRemake
{
    public abstract class HealthDecorator : Health
    {
        protected readonly Health Decorable;

        protected HealthDecorator(Health decorable)
            : base(decorable.Value)
        {
            Decorable = decorable ?? throw new ArgumentNullException(nameof(decorable));
        }

        public sealed override void TakeDamage(int damage)
        {
            Decorable.TakeDamage(AffectDamage(damage));
            
            Value = Decorable.Value;
        }

        protected abstract int AffectDamage(int damage);
    }
}
