namespace MyConsoleGame
{
    internal class Ghost : Monster
    {
        public Ghost(int health) : base(health) { }

        public override void Move()
        {
            Console.WriteLine($"{FullName}'s type of movement: flying");
        }

        public override void GetUpgraded()
        {
            _dodgeDamageChance = 0.6f;
            Console.WriteLine($"{FullName} got invisibility");
        }
    }
}
