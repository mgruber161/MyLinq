using System;
using System.Collections.Generic;
using MyLinq.Logic;

namespace MyLinq.ConApp
{
    class Program
    {
        static int[] IntArray = new int[] { 78, 9, 2, 4, 7, 16, 34, 35, 53, 76, 11, 13 };
        static void Main(string[] args)
        {


            Console.WriteLine("MyLinq-Demo\n");
            var even = IntArray.Filter(x => x % 2 == 0)
                .ForEach(x => Console.WriteLine(x));

            var doubleArray = IntArray.Map(x => x * 1.5)
                .ForEach(x => Console.WriteLine(x));

            var intList = new List<int>();
            for (int i = 0; i < 20; i += 3)
            {
                intList.Add(i);
            }

            var intArray2 = intList.ToArray();
            intArray2.ForEach(x => Console.WriteLine(x));

            var intList2 = intArray2.ToList().ForEach(x => Console.WriteLine(x));

            var sum = doubleArray.Sum(x => x * 2);
            Console.WriteLine(sum);

            var min = doubleArray.Min(x => x * 2);
            Console.WriteLine(min);

            var max = doubleArray.Max(x => x * 2);
            Console.WriteLine(max);

            var avg = doubleArray.Average(x => x * 2);
            Console.WriteLine(avg);

            var source = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(i);
            }

            source.ForEach((x, y) => System.Console.WriteLine($"{x} {y}"));
        }
    }
}
