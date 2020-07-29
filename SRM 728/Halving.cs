using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Halving {
    const int Inf = 1 << 22;

    Dictionary<int, int> dp;

	public int minSteps(int[] a) 
	{
		var minElement = a.Min();
        dp = new Dictionary<int, int>();
        return Search(minElement, a);
	}

    int Search(int current, int[] a)
    {
        if (dp.ContainsKey(current))
        {
            return dp[current];
        }
        else
        {
            var min = a.Sum(ai => Operate(ai, current));

            if (current > 1)
            {
                if (current % 2 == 0)
                {
                    min = Math.Min(min, Search(current / 2, a));
                }
                else
                {
                    min = Math.Min(min, Search(current / 2, a));
                    min = Math.Min(min, Search(current / 2 + 1, a));
                }
            }

            if (!dp.ContainsKey(current))
            {
                dp[current] = min;
            }

            return min;
        }
    }

	int Operate(int current, int target)
    {
        if (current == target)
        {
            return 0;
        }
        else if (current < target)
        {
            return Inf;
        }
        else if (current % 2 == 0)
        {
            return Operate(current / 2, target) + 1;
        }
        else
        {
            return Math.Min(Operate(current / 2, target) + 1, Operate(current / 2 + 1, target) + 1);
        }
    }
}
