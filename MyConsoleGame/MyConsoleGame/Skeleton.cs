namespace MyConsoleGame
{
    internal class Skeleton : Monster
    {
        public Skeleton(int health) : base(health) { }

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
