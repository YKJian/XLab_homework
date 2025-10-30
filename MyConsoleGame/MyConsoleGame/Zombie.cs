namespace MyConsoleGame
{
    internal class Zombie : Monster
    {
        public Zombie(int health) : base(health) { }

        public override void Move()
        {
            Console.WriteLine($"{FullName}'s type of movement: terrestrial");
        }

        public override void GetUpgraded()
        {
            _receivedDamageCoefficient = 0.75f;
            Console.WriteLine($"{FullName} got armor");
        }
    }
}
