using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var sum = int.Parse(Console.ReadLine());

            Console.WriteLine($"Is the sum of any pair equal to {sum}? :");
            Console.WriteLine(FindPariEqualSum(array, sum));
        }

        static bool FindPariEqualSum(int[] array, int sum)
        {
            var hashset = new HashSet<int>();

            foreach (var number in array)
            {
                if (hashset.Contains(number))
                {
                    return true;
                }

                hashset.Add(sum - number);
            }

            return false;
        }
    }
}
