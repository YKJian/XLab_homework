namespace ConsoleGameRemake
{
    public class MissEffectHealth : HealthDecorator
    {
        private readonly int _effect;

        public MissEffectHealth(int effect, Health decorable)
            : base(decorable)
        {
            _effect = Math.Clamp(effect, 0, 100);
        }

        protected override int AffectDamage(int damage)
        {
            return (int)(damage * ((100 - _effect) / 100f));
        }
    }
}
