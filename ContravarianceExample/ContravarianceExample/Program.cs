namespace ContravarianceExample
{
    public interface IMyList<in T>
    {
        void PrintElementType(T element);
    }

    public class MyList<T> : IMyList<T> 
    {
        public void PrintElementType(T element)
        {
            Console.WriteLine(element.GetType().Name); // Skeleton
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IMyList<Skeleton> myList = new MyList<Monster>();

            myList.PrintElementType(new Skeleton());
            Execute(new MyList<Monster>());
        }

        public static void Execute(IMyList<Skeleton> monsters) { }
    }

    public class Monster { }

    public class Skeleton : Monster { }
}
