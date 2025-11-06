namespace ConsoleGameRemake
{
    public class DodgeEffectHealth : HealthDecorator
    {
        private readonly int _dodgeDamageChance = 0;
        public Random random = new Random();

        public DodgeEffectHealth(Health decorable) 
            : base(decorable)
        {
            _dodgeDamageChance = 30;
        }

        protected override int AffectDamage(int damage)
        {
            int randomValue = random.Next(1, 101);

            if (randomValue > _dodgeDamageChance)
            {
                return damage;
            }
            else
            {
                Console.WriteLine("Monster dodged the attack");
                return 0;
            }
        }
    }
}
