using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.PrintList(); // 1234

            list.Insert(3, 1);
            list.PrintList(); // 12314

            list.Remove(2);
            list.PrintList(); // 1314

            list.RemoveAt(0);
            list.PrintList(); // 314

            Console.WriteLine(list[0]); // 3
            list[0] = 5;
            Console.WriteLine(list[0]); // 5

            list.Clear();
            list.PrintList();
        }
    }

    public class MyList<T>
    {
        private T[] _array;
        private int _capacity = 4;
        private int _count = 0;

        public MyList()
        {
            _array = new T[_capacity];
        }

        public void Add(T item)
        {
            CheckSize();

            _array[_count] = item;
            _count++;
        }

        public void Insert(int index, T item)
        {
            CheckSize();

            for (int i = _capacity - 1; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = item;
            _count++;
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(_array, item);

            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i <= _count; i++)
            { 
                _array[i] = _array[i + 1];
            }
            _count--;
        }

        public void Clear()
        {
            _capacity = 4;
            _count = 0;
            _array = new T[_capacity];
        }

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public void PrintList()
        {
            if (_count > 0)
            {
                for (int i = 0; i < _count; i++)
                {
                    Console.Write(_array[i]);
                }
                Console.WriteLine();
            }
        }

        private void CheckSize()
        {
            if (_count == _capacity)
            {
                T[] tempArray = _array;
                _capacity *= 2;
                _array = new T[_capacity];

                for (int i = 0; i < _count; i++)
                {
                    _array[i] = tempArray[i];
                }

                tempArray = new T[0];
            }
        }
    }
}
