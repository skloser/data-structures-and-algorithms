using System;
using System.Linq;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(" ", new int[] { 2, 1, 54, 32, 66 }.OrderBy(n => n)));
            //Console.WriteLine(ReverseRecursively("Hello World!"));


            Console.WriteLine(string.Join(" ", BubbleSort(new int[] { 2, 1, 54, 32, 66, 54 })));
            Console.WriteLine(string.Join(" ", BubbleSort2Original(new int[] { 2, 1, 54, 32, 66, 54 })));
            Console.WriteLine(string.Join(" ", SelectionSort(new int[] { 2, 1, 54, 32, 66, 54 })));
        }

        /*
            Exercise: Reverse String With Recursion
         
         */

        static string ReverseRecursively(string input)
        {
            if (input.Length == 1)
            {
                return input[0].ToString();
            }

            return input[input.Length - 1] + ReverseRecursively(input.Substring(0, input.Length - 1));
        }

        /*
         
            Bubble Sort
         
         */
        static int[] BubbleSort(int[] nums)
        {
            var iterationsCount = nums.Length;
            //After the first iteration, the largest number will be at the end. This means after each iteration, the last digit will be the next to greatest
            while (iterationsCount > 1)
            {

                for (int i = 0; i < iterationsCount - 1; i++)
                {
                    var swap = nums[i];

                    if (nums[i] > nums[i + 1])
                    {
                        swap = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = swap;
                    }
                }

                iterationsCount--;
            }

            return nums;
        }

        /*
            
            Bubble sort 2( Original )
         
         */

        static int[] BubbleSort2Original(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        var swap = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = swap;
                    }
                }
            }

            return nums;
        }

        static int[] SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                var minIndex = i;
                var minValueSwap = nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }

                nums[i] = nums[minIndex];
                nums[minIndex] = minValueSwap;
            }

            return nums;
        }
    
        static int[] InsertionSort(int[] nums)
        {
            var counter = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[counter])
                {
                    var swap = nums[i];
                    nums[i] = nums[counter];
                    nums[counter] = swap;

                    counter++;
                }
            }

            return nums;
        }

    }
}
