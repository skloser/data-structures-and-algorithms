using System;
using System.Collections.Generic;

namespace Caching
{
    class Program
    {
        private static Dictionary<int, int> cache;
        static void Main(string[] args)
        {
            //cache = new Dictionary<int, int>();
            //Console.WriteLine(MemoizedAddto80(5));
            //Console.WriteLine(MemoizedAddto80(7));
            //Console.WriteLine(MemoizedAddto80(6));
            //Console.WriteLine(MemoizedAddto80(6));

            var fibMemo = FibonacciMemoized();
            Console.WriteLine(fibMemo(21));

        }

        static Func<int, int> FibonacciMemoized()
        {
            var cache = new Dictionary<int, int>();
            var calculations = 0;

            Func<int, int> Fib = null;

            Fib = (int n) =>
            {
                calculations++;
                if (cache.ContainsKey(n))
                {
                    return cache[n];
                }
                else
                {
                    if (n < 2)
                    {
                        return n;
                    }
                    else
                    {
                        cache[n] = Fib(n - 1) + Fib(n - 2);
                        return cache[n];
                    }
                };
            };

            return Fib;
        }

        static int MemoizedAddto80(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            Console.WriteLine("Long time");
            cache.Add(n, n + 80);
            return cache[n];
        }
    }
}
