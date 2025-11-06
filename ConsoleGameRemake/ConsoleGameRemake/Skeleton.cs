namespace ConsoleGameRemake
{
    public class Skeleton : Monster
    {
        public Skeleton(int hp, string name = "Noname") 
            : base(hp, name) { }

        public Skeleton(Health health, string name = "Noname") 
            : base(health, name) { }
    }
}
