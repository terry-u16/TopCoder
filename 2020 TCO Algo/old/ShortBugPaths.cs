using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class ShortBugPaths
{
	public int count(int N, int[] D, int J)
	{
		const int mod = 1000000007;

        if (N < 300)
        {
			var jumps = new long[J + 1, N, N];
            for (int row = 0; row < N; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    jumps[0, row, column] = 1;
                }
            }

            for (int count = 0; count < J; count++)
            {
                for (int row = 0; row < N; row++)
                {
                    for (int column = 0; column < N; column++)
                    {
                        foreach (var distance in D)
                        {
                            for (int dr = -distance; dr <= distance; dr++)
                            {
                                if (Math.Abs(dr) == distance)
                                {
                                    var dc = 0;
                                    var nextRow = row + dr;
                                    var nextColumn = column + dc;
                                    if (InMap(nextRow, nextColumn, N))
                                    {
                                        jumps[count + 1, nextRow, nextColumn] += jumps[count, row, column];
                                        jumps[count + 1, nextRow, nextColumn] %= mod;
                                    }
                                }
                                else
                                {
                                    for (int sign = -1; sign <= 1; sign += 2)
                                    {
                                        var dc = sign * Math.Abs(distance - dr);
                                        var nextRow = row + dr;
                                        var nextColumn = column + dc;
                                        if (InMap(nextRow, nextColumn, N))
                                        {
                                            jumps[count + 1, nextRow, nextColumn] += jumps[count, row, column];
                                            jumps[count + 1, nextRow, nextColumn] %= mod;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            long result = 0;
            for (int row = 0; row < N; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    result += jumps[J, row, column];
                    result %= mod;
                }
            }
            return (int)result;
        }
        else
        {
            return 0;
        }

    }

	bool InMap(int row, int column, int N)
    {
		return unchecked((uint)row < N && (uint)column < N);
    }
}