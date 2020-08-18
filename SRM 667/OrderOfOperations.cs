using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class OrderOfOperations
{
	public int minTime(string[] s)
	{
		var operations = s.Select(op => Convert.ToInt32(op, 2)).OrderBy(op => PopCount(op)).ToArray();
		var final = operations.Aggregate(0, (m, op) => m | op);

		const int Inf = 1 << 28;
		var dp = new int[GetDpLength(final)];
        for (int i = 0; i < dp.Length; i++)
        {
			dp[i] = Inf;
        }

		dp[0] = 0;

        for (int flag = 0; flag < dp.Length; flag++)
        {
            foreach (var op in operations)
            {
                var newMemory = CountNewMemory(flag, op);
                dp[flag | op] = Math.Min(dp[flag | op], dp[flag] + newMemory * newMemory);
            }
        }

        return dp[final];
	}

	int CountNewMemory(int memory, int operaton)
    {
		return PopCount(~memory & operaton);
    }

	int GetDpLength(int n)
    {
		var result = 1;
        while (n >= result)
        {
			result <<= 1;
        }
		return result;
    }

	int PopCount(int n)
    {
		var result = 0;
        while (n > 0)
        {
			result += n & 1;
			n >>= 1;
        }
		return result;
    }
}