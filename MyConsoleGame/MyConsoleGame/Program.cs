#nullable disable

using System.Security.Principal;

namespace MyConsoleGame
{
    internal class Program
    {
        public static List<Monster> monsterList = new List<Monster>();
        public static int monsterIndex;

        static void Main(string[] args)
        {
            string input = null;
            int damage = 100;
            Random random = new Random();

            Console.WriteLine("Welcome to my console game!");

            do
            {
                OpenMenu();

                input = Console.ReadLine();
                monsterIndex = -1;

                switch (input)
                {
                    case "1":
                        Skeleton skeleton = new Skeleton(300);
                        AddMonster(skeleton);
                        break;
                    
                    case "2":
                        Zombie zombie = new Zombie(500);
                        AddMonster(zombie);
                        break;
                    
                    case "3":
                        Ghost ghost = new Ghost(200);
                        AddMonster(ghost);
                        break;
                    
                    case "4":
                        if (TryChooseMonster()) monsterList[monsterIndex].TakeDamage(damage);
                        break;
                    
                    case "5":
                        monsterIndex = random.Next(monsterList.Count);
                        monsterList[monsterIndex].TakeDamage(damage);
                        break;
                    
                    case "6":
                        if (TryChooseMonster()) monsterList[monsterIndex].GetUpgraded();
                        break;
                    
                    case "7":
                        if (TryChooseMonster()) monsterList[monsterIndex].Die();
                        break;
                    
                    case "8":
                        PrintAllMonsters();
                        break;

                    case "9":
                        if (TryChooseMonster()) monsterList[monsterIndex].Move();
                        break;
                }

            } while (input?.Trim().ToLower() != "q");
        }

        private static void OpenMenu()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Create a skeleton");
            Console.WriteLine("2. Create a zombie");
            Console.WriteLine("3. Create a ghost");
            Console.WriteLine("4. Attack chosen monster");
            Console.WriteLine("5. Attack random monster");
            Console.WriteLine("6. Upgrade chosen monster");
            Console.WriteLine("7. Destroy chosen monster");
            Console.WriteLine("8. Print all monster list");
            Console.WriteLine("9. Print chosen monster's movement type");
            Console.WriteLine("Press 'q' to quit");
        }

        private static void AddMonster(Monster monster)
        {
            monsterList.Add(monster);
            Console.WriteLine($"{monster.ClassType} {monster.Name} added");
            monster.Eliminate += DeleteMonster;
        }

        private static bool TryChooseMonster()
        {
            if (monsterList.Count <= 0)
            {
                Console.WriteLine("No monsters out here");
                return false;
            }

            do
            {
                Console.WriteLine("Choose a monster (enter correct index, index > 0): ");
                PrintAllMonsters();
                monsterIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            } while ((monsterIndex < 0) || (monsterIndex >= monsterList.Count));
            return true;
        }

        private static void PrintAllMonsters()
        {
            Console.WriteLine("List of all monsters:");
            foreach (Monster monster in monsterList)
            {
                Console.WriteLine($"{monster.ClassType} {monster.Name}");
            }
        }

        private static void DeleteMonster(Monster monster)
        {
            monsterList.Remove(monster);
        }
    }
}
