using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class WaterTank {
	public double minOutputRate(int[] t, int[] x, int C) {
        Check(t, x, C, 1);
		return BoundaryBinarySearch(rate => Check(t, x, C,rate), 1e6, -double.Epsilon);
	}

    public static double BoundaryBinarySearch(Predicate<double> predicate, double ok, double ng)
    {
        const double eps = 1e-9;
        // ‚ß‚®‚éŽ®“ñ•ª’Tõ
        while (Math.Abs(ok - ng) > eps)
        {
            double mid = (ok + ng) / 2;
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

    bool Check(int[] t, int[] x, int C, double rate)
    {
		var current = 0.0;
        for (int i = 0; i < t.Length; i++)
        {
            current += (x[i] - rate) * t[i];
            if (current > C)
            {
                return false;
            }
            else if (current < 0)
            {
                current = 0;
            }
        }

        return true;
    }
}
