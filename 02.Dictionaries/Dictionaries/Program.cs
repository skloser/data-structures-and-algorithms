using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstRecurringCharacter(new int[4] { 2, 3, 4, 5 }));
        }

        /*
     
            Google question: 
            
            Return the first recurring characted in array
        
            Given an array: [2,5,1,2,3,5,1,2,4]
            It should return 2

            Give an array: [2,1,1,2,3,5,1,2,4]
            It should return 1

            Give an array: [2,3,4,5]
            it should return undefined
     
            
        */

        static int FirstRecurringCharacter(int[] array)
        {
            var set = new HashSet<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (set.Contains(array[i]))
                {
                    return array[i];
                }

                set.Add(array[i]);
            }

            throw new ArgumentException("Array does not contain reccuring characters");
        }
    }

    
}
