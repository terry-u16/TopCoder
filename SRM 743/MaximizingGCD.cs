using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class MaximizingGCD {
	public int maximumGCDPairing(int[] A) 
    {
        var divisiors = new HashSet<int>();

        for (int i = 0; i < A.Length; i++)
        {
            for (int j = i + 1; j < A.Length; j++)
            {
                foreach (var div in GetDivisiors(A[i] + A[j]))
                {
                    divisiors.Add(div);
                }
            }
        }

        var max = 0;

        foreach (var div in divisiors)
        {
            var selected = new bool[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                if (!selected[i])
                {
                    var ok = false;
                    selected[i] = true;
                    for (int j = i + 1; j < A.Length; j++)
                    {
                        if (!selected[j] && (A[i] + A[j]) % div == 0)
                        {
                            ok = true;
                            selected[j] = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        break;
                    }
                }
            }
            if (selected.All(b => b))
            {
                max = Math.Max(max, div);
            }
        }

		return max;
	}

	List<int> GetDivisiors(int n)
    {
        var list = new List<int>();
        for (int d = 1; d * d <= n; d++)
        {
            if (n % d == 0)
            {
                list.Add(d);
                list.Add(n / d);
            }
        }
        return list;
    }
}
