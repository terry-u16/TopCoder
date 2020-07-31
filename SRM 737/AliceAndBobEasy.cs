using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class AliceAndBobEasy 
{
	public int[] make(int N) 
	{
		const int MaxBit = 28;
		const int BaseNumber = 1 << MaxBit;
		var results = new List<int>(N);

        for (int i = 0; i < N; i++)
        {
            results.Add(BaseNumber | i);
        }

        if (N % 2 == 0)
        {
            results.RemoveAt(results.Count - 1);
            results.Add(1);
        }

        return results.ToArray();
	}

}
