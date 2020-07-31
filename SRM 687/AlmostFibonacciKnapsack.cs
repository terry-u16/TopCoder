using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class AlmostFibonacciKnapsack 
{
	public int[] getIndices(long x)
    {
        var fibonacci = InitializeFibonacci(x);

        long[] prefixSum = CreatePrefixSum(fibonacci);

        var result = Dfs(x, fibonacci, prefixSum, 0, fibonacci.Count - 1);

        if (result != null)
        {
            return result.Select(i => i + 1).ToArray();
        }
        else
        {
            return new int[] { -1 };
        }
    }

    private static long[] CreatePrefixSum(List<long> fibonacci)
    {
        var prefixSum = new long[fibonacci.Count + 1];
        for (int i = 0; i < fibonacci.Count; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + fibonacci[i];
        }

        return prefixSum;
    }

    private static List<long> InitializeFibonacci(long x)
    {
        var list = new List<long>();
        list.Add(2);
        list.Add(3);

        for (int i = 2; list[list.Count - 1] <= x; i++)
        {
            var next = list[i - 2] + list[i - 1] - 1;
            list.Add(next);
        }

        list.RemoveAt(list.Count - 1);
        return list;
    }

    List<int> Dfs(long x, List<long> fibonacci, long[] prefixSum, long currentSum, int index)
    {
        if (index == 0)
        {
            if (currentSum == x)
            {
                return new List<int>();
            }
            else if (currentSum + fibonacci[index] == x)
            {
                var result = new List<int> { index };
                return result;
            }
            else
            {
                return null;
            }
        }
        else
        {
            if (currentSum > x || currentSum + prefixSum[index + 1] < x)
            {
                return null;
            }
            else if (currentSum == x)
            {
                return new List<int>();
            }
            else
            {
                var select = Dfs(x, fibonacci, prefixSum, currentSum + fibonacci[index], index - 1);
                if (select != null)
                {
                    select.Add(index);
                    return select;
                }
                var notSelect = Dfs(x, fibonacci, prefixSum, currentSum, index - 1);
                if (notSelect != null)
                {
                    return notSelect;
                }

                return null;
            }
        }
    }
}
