using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class RepeatString {
	public int minimalModify(string s) 
	{
		var min = s.Length;

        for (int length = 0; length < s.Length; length++)
        {
			var a = s.Substring(0, length);
			var b = s.Substring(length, s.Length - length);
            min = Math.Min(min, Levenshtein(a, b));
        }

		return min;
	}

	int Levenshtein(string a, string b)
    {
		var minOperations = new int[a.Length + 1, b.Length + 1];
        for (int i = 0; i <= a.Length; i++)
        {
			minOperations[i, 0] = i;
        }
        for (int j = 0; j <= b.Length; j++)
        {
            minOperations[0, j] = j;
        }

        for (int i = 1; i <= a.Length; i++)
        {
            for (int j = 1; j <= b.Length; j++)
            {
                var min = Math.Min(minOperations[i - 1, j] + 1, minOperations[i, j - 1] + 1);
                if (a[i - 1] == b[j - 1])
                {
                    min = Math.Min(min, minOperations[i - 1, j - 1]);
                }
                else
                {
                    min = Math.Min(min, minOperations[i - 1, j - 1] + 1);
                }
                minOperations[i, j] = min;
            }
        }

        return minOperations[a.Length, b.Length];
    }
}
