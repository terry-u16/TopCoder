using System;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var hoge = new PerfectSquares();

            while (true)
            {
                var min = random.Next(0, 1000000000);
                var max = random.Next(min, 1000000000);
                var maxN = random.Next(2, 31);

                Console.WriteLine($"{min} {max} {maxN}");
                var tested = hoge.countRange(min, max, maxN);
                var guchoku = Guchoku(min, max, maxN);

                Console.WriteLine($"tested : {tested}");
                Console.WriteLine($"guchoku: {guchoku}");

                if (tested == guchoku)
                {
                    Console.WriteLine("OK");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("NG");
                    Console.ReadKey();
                }
            }
        }

        public static int Guchoku(long minimum, long maximum, int maxN)
        {
            var set = new HashSet<long>();

            var count = 0;
            for (long i = 1; i * i <= maximum; i++)
            {
                var current = i;
                for (int pow = 2; pow <= maxN; pow++)
                {
                    current *= i;

                    if (current > maximum)
                    {
                        break;
                    }
                    else if (minimum <= current && set.Add(current))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
