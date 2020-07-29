using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class TopXorer {
	public int maximalRating(int[] x) {
		var rating = 0;
		Array.Sort(x);
		Array.Reverse(x);

        var bits = new int[32];

        foreach (var person in x)
        {
            for (int shift = 0; shift < bits.Length; shift++)
            {
                if ((person & (1 << shift)) > 0)
                {
                    bits[shift]++;
                }
            }
        }

        for (int shift = bits.Length - 1; shift >= 0; shift--)
        {
            if (bits[shift] >= 2)
            {
                rating |= (1 << (shift + 1)) - 1;
                break;
            }
            else if (bits[shift] == 1)
            {
                rating |= 1 << shift;
            }
        }

		return rating;
	}

	int GetMsb(int n)
    {
		var result = 0;
        n >>= 1;
        while (n > 0)
        {
            result++;
            n >>= 1;
        }
        return result;
    }
}
