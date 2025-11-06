namespace ConsoleGameRemake
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var monsters = new List<Monster>();

            Console.WriteLine("Welcome to XLab Diablo\n");

            while (true)
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Add Skeleton");
                Console.WriteLine("2. Take Damage to the first monster");
                Console.WriteLine("3. Upgrade the first monster");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                var input = ReadInput();

                Console.Clear();

                if (input is "1") AddSkeleton(monsters);
                else if (input is "2") TakeDamageToMonster(monsters[0]);
                else if (input is "3") UpgradeMonster(monsters[0]);
                else if (input is "4")
                {
                    break;
                }
            }
        }

        private static void AddSkeleton(List<Monster> monsters) =>
            monsters.Add(new Skeleton(100, $"Monster {monsters.Count + 1}"));

        private static void TakeDamageToMonster(Monster monster)
        {
            Console.Write("Enter damage: ");
            var input = ReadInput();

            if (int.TryParse(input, out var damage))
            {
                var oldHp = monster.Hp;
                monster.TakeDamage(damage);
                var newHp = monster.Hp;

                Console.WriteLine($"{monster.Name} took {damage} damage. Hp: {oldHp} -> {newHp}");
            }
            else
            {
                Console.WriteLine($"Invalid damage {input}");
            }
        }

        private static void UpgradeMonster(Monster monster)
        {
            var health = monster.HealthComponent;
            health = new MissEffectHealth(20, health);
            health = new DodgeEffectHealth(health);
            health = new LeatherArmorHealth(health);
            health = new IronArmorHealth(health); // Exception
            monster.HealthComponent = health;
        }

        private static string ReadInput() =>
            Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
    }
}
