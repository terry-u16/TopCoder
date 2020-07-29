using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class EraseToGCD {
	public int countWays(int[] S, int goal) {
        const int Modulo = 1000000007;

		var availables = new List<int>();
        foreach (var si in S)
        {
            if (si % goal == 0)
            {
                availables.Add(si / goal);
            }
        }

        if (availables.Count == 0)
        {
            return 0;
        }

        int max = availables.Max() + 1;
        var counts = new int[availables.Count + 1, max];
        counts[0, 0] = 1;

        for (int i = 0; i < availables.Count; i++)
        {
            for (int gcd = 0; gcd < max; gcd++)
            {
                // ‘I‚Î‚È‚¢
                counts[i + 1, gcd] += counts[i, gcd];
                counts[i + 1, gcd] %= Modulo;

                // ‘I‚Ô
                var newGcd = Gcd(gcd, availables[i]);
                counts[i + 1, newGcd] += counts[i, gcd];
                counts[i + 1, newGcd] %= Modulo;
            }
        }

        return counts[availables.Count, 1];
	}

    public static long Gcd(long a, long b)
    {
        if (a < b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        if (b == 0)
        {
            return a;
        }
        else
        {
            return Gcd(b, a % b);
        }
    }
}
