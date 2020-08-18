using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class LexicographicPartition
{
	public int[] positiveSum(int n, int[] Aprefix, int seed, int Arange)
	{
		var a = GenerateA(n, Aprefix, seed, Arange);

		var prefixSum = new long[n + 1];

        for (int i = 0; i < a.Length; i++)
        {
			prefixSum[i + 1] = prefixSum[i] + a[i];
        }

        if (prefixSum[prefixSum.Length - 1] <= 0)
        {
			return new int[] { -1 };
        }
        else
        {
            var separations = new List<int>() { 0 };

            for (int i = 1; i < prefixSum.Length; i++)
            {
                if (prefixSum[i] - prefixSum[separations[separations.Count - 1]] > 0 && prefixSum[prefixSum.Length - 1] - prefixSum[i] > 0)
                {
                    separations.Add(i);
                }
            }

            var lengths = new List<int>();
            for (int i = 0; i + 1 < separations.Count; i++)
            {
                lengths.Add(separations[i + 1] - separations[i]);
            }

            lengths.Add(a.Length - separations[separations.Count - 1]);

            var result = new int[1 + Math.Min(lengths.Count, 200)];
            result[0] = lengths.Count;

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = lengths[i - 1];
            }

            return result;
        }
	}

	int[] GenerateA(int n, int[] aPrefix, int seed, int aRange)
    {
		var a = new int[n];
		Array.Copy(aPrefix, a, aPrefix.Length);

		long state = seed;
        for (int i = aPrefix.Length; i < a.Length; i++)
        {
			state = 1103515245 * state + 12345;
			a[i] = (int)(state % (2 * aRange + 1));
			a[i] -= aRange;
			state %= 1 << 31;
        }

		return a;
    }
}
