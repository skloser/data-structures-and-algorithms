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

            //Console.WriteLine(string.Join(" ", Rotate(new int[] { -1, -100, 3, 99 }, 2)));

            //Console.WriteLine(MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));


            //Console.WriteLine(string.Join(" ", TwoSum(new int[] { 3, 3 }, 6)));


            //Console.WriteLine(ContainsDuplicate(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }));



            //var arrayWithZeros = new int[] { 0, 1, 0, 3, 12 };
            //arrayWithZeros = MoveZeroesToEnd(arrayWithZeros);
            //Console.WriteLine(string.Join(" ", MoveZeroesToEnd(arrayWithZeros)));

            //var krumStr = "Krum will do it!";
            //Console.WriteLine(krumStr.Reverse());




            //var array1 = new int[4] { 0, 3, 4, 31 };
            //var array2 = new int[3] { 4, 6, 30 };

            //Console.WriteLine(string.Join(" ", MergeTwoSortedArrays(array1, array2)));

            //var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            //var sum = int.Parse(Console.ReadLine());

            //Console.WriteLine($"Is the sum of any pair equal to {sum}? :");
            //Console.WriteLine(FindPairEqualToSum(array, sum));


        }


        /*
         
            By given array and sum, find a pair that is equal to the sum
            
            Example: [1,2,3,3] Sum: 8
                returns false;

        
            Example: [1,2,4,4] Sum: 8
                returns true;

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

        static int[] TwoSum(int[] nums, int target)
        {
            var resultArray = new int[2];

            var set = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (set.ContainsValue(nums[i]))
                {
                    resultArray[0] = i;
                    resultArray[1] = set.FirstOrDefault(x => x.Value == nums[i]).Key;

                    break;
                }

                set.Add(i, target - nums[i]);
            }

            return resultArray;
        }

        /*
         
        Given two sorted arrays, merge both

        Example: array1 = [0,3,4,31], array2=[4,6,30]
        Output= [0,3,4,4,6,30,31]
         
         */

        static int[] MergeTwoSortedArrays(int[] array1, int[] array2)
        {
            if (array1.Length == 0)
            {
                return array2;
            }

            if (array2.Length == 0)
            {
                return array1;
            }

            var a = 0;
            var b = 0;
            var i = 0;

            var resultArray = new int[array1.Length + array2.Length];
            var count1 = array1.Length;
            var count2 = array2.Length;

            while (a < count1 && b < count2)
            {
                if (array1[a] <= array2[b])
                {
                    resultArray[i] = array1[a];
                    i++;
                    a++;
                }
                else
                {
                    resultArray[i] = array2[b];
                    i++;
                    b++;
                }
            }


            if (a < count1)
            {
                for (int j = a; j < array1.Length; j++)
                {
                    resultArray[i] = array1[j];
                    i++;
                }
            }
            else
            {
                for (int j = b; j < array2.Length; j++)
                {
                    resultArray[i] = array2[j];
                    i++;
                }
            }

            return resultArray;
        }


        /*
            Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
            Note that you must do this in-place without making a copy of the array.

            Example 1:

                Input: nums = [0,1,0,3,12]
                Output: [1,3,12,0,0]

                Example 2:

                Input: nums = [0]
                Output: [0]
 

                Constraints:

                1 <= nums.length <= 104
                -231 <= nums[i] <= 231 - 1
 

         */
        static void MoveZeroesToEnd(int[] nums)
        {

            if (nums == null)
            {
                throw new ArgumentNullException("Array may not be null.");
            }

            if (!nums.Contains(0))
            {
                return;
            }

            var notZeroIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[notZeroIndex] = nums[i];
                    notZeroIndex++;
                }
            }

            while (notZeroIndex < nums.Length)
            {
                nums[notZeroIndex] = 0;
                notZeroIndex++;
            }
        }

        /*
          Contains Duplicate - https://leetcode.com/problems/contains-duplicate/description/
         
            Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

            Example 1:

            Input: nums = [1,2,3,1]
            Output: true
            Example 2:

            Input: nums = [1,2,3,4]
            Output: false
            Example 3:

            Input: nums = [1,1,1,3,3,4,3,2,4,2]
            Output: true
         
         */

        static bool ContainsDuplicate(int[] nums)
        {
            if (nums == null)
            {
                return false;
            }

            if (nums.Length == 1)
            {
                return false;
            }

            var set = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    return true;
                }

                set.Add(nums[i]);
            }

            return false;
        }

        /*
         
            Maximum Subarray - https://leetcode.com/problems/maximum-subarray/

        Example 1:

        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:

        Input: nums = [1]
        Output: 1
        Example 3:

        Input: nums = [5,4,-1,7,8]
        Output: 23
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -105 <= nums[i] <= 105
         */

        static int MaxSubArray(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException();
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            var currentSum = nums[0];
            var maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(currentSum, maxSum);
            }

            return maxSum;
        }

        /*
         
            189. Rotate Array - https://leetcode.com/problems/rotate-array/description/

            Given an array, rotate the array to the right by k steps, where k is non-negative.

            Example 1:

            Input: nums = [1,2,3,4,5,6,7], k = 3
            Output: [5,6,7,1,2,3,4]
            Explanation:
            rotate 1 steps to the right: [7,1,2,3,4,5,6]
            rotate 2 steps to the right: [6,7,1,2,3,4,5]
            rotate 3 steps to the right: [5,6,7,1,2,3,4]
            Example 2:

            Input: nums = [-1,-100,3,99], k = 2
            Output: [3,99,-1,-100]
            Explanation: 
            rotate 1 steps to the right: [99,-1,-100,3]
            rotate 2 steps to the right: [3,99,-1,-100]
 

            Constraints:

            1 <= nums.length <= 105
            -231 <= nums[i] <= 231 - 1
            0 <= k <= 105
         */

        static void Rotate(int[] nums, int k)
        {
            if (nums == null)
            {
                throw new ArgumentNullException();
            }

            if (nums.Length == 1)
            {
                return;
            }

            if (k == 0)
            {
                return;
            }

            var resultArray = new int[nums.Length];
            var j = 0;


            for (int i = nums.Length - k; i < nums.Length; i++)
            {
                resultArray[j] = nums[i];
                j++;
            }

            for (int i = 0; i < nums.Length - k; i++)
            {
                resultArray[j] = nums[i];
                j++;
            }

            nums = resultArray;
        }
    }
}
