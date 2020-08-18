using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class PerfectSquares
{
	public int countRange(long minimum, long maximum, int maxN)
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
