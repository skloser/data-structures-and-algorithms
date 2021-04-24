using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public static class Extensions
    {
        /* Fill array with test data */
        public static string[] Fill(this string[] array, string testData = "test")
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = testData;
            }

            return array;
        }
    }
}
