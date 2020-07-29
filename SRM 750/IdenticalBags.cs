using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class IdenticalBags {
	public long makeBags(long[] candy, long bagSize) {
		return BoundaryBinarySearch(bags => Composable(candy, bagSize, bags), 0, long.MaxValue);
	}

    bool Composable(long[] candy, long bagSize, long bagCount)
    {
        long taken = 0;
        foreach (var c in candy)
        {
            taken += c / bagCount;
        }
        return taken >= bagSize;
    }

    long BoundaryBinarySearch(Predicate<long> predicate, long ok, long ng)
    {
        while (Math.Abs(ok - ng) > 1)
        {
            long mid = (ok + ng) / 2;
            if (predicate(mid))
            {
                ok = mid;
            }
            else
            {
                ng = mid;
            }
        }
        return ok;
    }
}
