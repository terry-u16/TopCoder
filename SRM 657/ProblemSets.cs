using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class ProblemSets {
	public long maxSets(long E, long EM, long M, long MH, long H) 
    {
        return BoundaryBinarySearch(sets => CanCompose(E, EM, M, MH, H, sets), 0, 2000000000000000001L);
    }

    public static long BoundaryBinarySearch(Predicate<long> predicate, long ok, long ng)
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


    bool CanCompose(long e, long em, long m, long mh, long h, long sets)
    {
        if (e < sets)
        {
            em -= sets - e;
        }

        if (h < sets)
        {
            mh -= sets - h;
        }

        if (em < 0 || mh < 0)
        {
            return false;
        }

        m += em + mh;

        return m >= sets;
    }
}
