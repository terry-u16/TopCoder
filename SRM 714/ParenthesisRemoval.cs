using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class ParenthesisRemoval {
	public int countWays(string s) {
		const int Mod = 1000000007;
		var count = 1L;
		var current = 0;

        foreach (var c in s)
        {
            if (c == '(')
            {
                current++;
            }
            else
            {
                count *= current--;
                count %= Mod;
            }
        }

		return (int)count;
	}

}
