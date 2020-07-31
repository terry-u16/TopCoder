using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class TrySail {
	public int get(int[] strength) 
	{
        const int MaxStrength = 256;
		var dp = new bool[strength.Length + 1, MaxStrength, MaxStrength, 4];
		dp[1, 0, 0, 0] = true;

        for (int student = 1; student < strength.Length; student++)
        {
            for (int teamA = 0; teamA < MaxStrength; teamA++)
            {
                for (int teamB = 0; teamB < MaxStrength; teamB++)
                {
                    for (int flag = 0; flag < 4; flag++)
                    {
                        // A‚É“ü‚ê‚é
                        dp[student + 1, teamA ^ strength[student], teamB, flag | 1] |= dp[student, teamA, teamB, flag];

                        // B‚É“ü‚ê‚é
                        dp[student + 1, teamA, teamB ^ strength[student], flag | 2] |= dp[student, teamA, teamB, flag];

                        // C‚É“ü‚ê‚é
                        dp[student + 1, teamA, teamB, flag] |= dp[student, teamA, teamB, flag];
                    }
                }
            }
        }

        var xorSum = strength.Aggregate(0, (xor, s) => xor ^ s);
        var max = 0;
        for (int teamA = 0; teamA < MaxStrength; teamA++)
        {
            for (int teamB = 0; teamB < MaxStrength; teamB++)
            {
                if (dp[strength.Length, teamA, teamB, 3])
                {
                    var teamC = xorSum ^ teamA ^ teamB;
                    max = Math.Max(max, teamA + teamB + teamC);
                }
            }
        }

        return max;
	}
}
