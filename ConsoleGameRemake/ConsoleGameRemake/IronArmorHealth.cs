namespace ConsoleGameRemake
{
    public sealed class IronArmorHealth : HealthDecorator
    {
        private readonly int _armor;

        public IronArmorHealth(Health decorable) 
            : base(decorable)
        {
            if (decorable.IsArmored)
            {
                throw new InvalidOperationException("You can't put more than 1 set of armor on the monster");
            }

            IsArmored = true;
            _armor = 50;
        }

        protected override int AffectDamage(int damage)
        {
            return damage - _armor;
        }
    }
}
