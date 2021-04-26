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

        public static string Reverse(this string str)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length == 1)
            {
                return str;
            }

            var newStr = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                newStr += str[i];
            }

            return newStr;
        }
    }
}
