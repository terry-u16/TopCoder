using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class MagicNumberThree {
	public int countSubsequences(string s) {
		const int Mod = 1000000007;
		var dp = new long[s.Length + 1, 3];
		dp[0, 0] = 1;

        for (int i = 0; i < s.Length; i++)
        {
			// Žæ‚ç‚È‚¢
			dp[i + 1, 0] += dp[i, 0];
			dp[i + 1, 1] += dp[i, 1];
			dp[i + 1, 2] += dp[i, 2];

			var current = s[i] - '0';

			// Žæ‚é
			dp[i + 1, current % 3] += dp[i, 0];
			dp[i + 1, (current + 1) % 3 ] += dp[i, 1];
			dp[i + 1, (current + 2) % 3] += dp[i, 2];
		}

		return (int)((dp[s.Length, 0] + Mod - 1) % Mod);
	}
}
