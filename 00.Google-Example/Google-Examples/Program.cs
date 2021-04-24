using System;
using System.Collections.Generic;
using System.Linq;

namespace Google_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Exercise 1
                var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                var sum = int.Parse(Console.ReadLine());

                Console.WriteLine($"Is the sum of any pair equal to {sum}? :");
                Console.WriteLine(FindPairEqualToSum(array, sum));
            */

            /* Exercies 2*/

            Console.WriteLine($" Do both arrays have a common item? : {CheckIfBothArraysHaveCommonItem(new string[] { "a", "q", "c" }, new string[] { "x", "y", "d" })}");
        }


        /*
            Exercise 1

            Given an array of integers and a sum, find if there is a pair in the array that is equal to the sum.

            Example1: array = [1,2,3,3]
                     sum = 8
                    return false

            Example2: array = [1,2,2,4,4]
                     sum = 8
                    return true
         */
        static bool FindPairEqualToSum(int[] array, int sum)
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


        /*
            Exercise 2

            Given two arrays, find if the there are common elements in both arrays

            Example1: array = ['a', 'b', 'c', 'x']
                     array = ['z', 'y', 'd', 'e']
                        return false

        
            Example2: array = ['a', 'b', 'c', 'x']
                     array = ['z', 'y', 'd', 'e']
                        return false
         */
        static bool CheckIfBothArraysHaveCommonItem(string[] array1, string[] array2)
        {
            //Check if arrays are null
            //if (array1 is null)
            //{
            //    throw new ArgumentNullException(nameof(array1));
            //}

            //if (array2 is null)
            //{
            //    throw new ArgumentNullException(nameof(array2));
            //}

            // Complexity - O(m*n), arrays can have different length
            //for (int i = 0; i < array1.Length; i++)
            //{
            //    for (int j = 0; j < array2.Length; j++)
            //    {
            //        if (array1[i] == array2[j])
            //        {
            //            return true;
            //        }
            //    }
            //}


            // Complexity - O(m + n), arrays can have different length
            var set = new HashSet<string>();

            for (int i = 0; i < array1.Length; i++)
            {
                set.Add(array1[i]);
            }

            for (int j = 0; j < array2.Length; j++)
            {
                if (set.Contains(array2[j]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
