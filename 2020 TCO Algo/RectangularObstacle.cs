using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class RectangularObstacle
{
	public long countReachable(int x1, int x2, int y1, int y2, int s)
	{
		long lower = (long)(s + 1) * (s + 1);
		long upper = (long)s * s;

		if (y1 <= s)
		{
			upper -= (long)(s - y1 + 1) * (s - y1 + 1);
			var toLeftBottom = GetManhattan(0, x1 - 1, 0, y1);
			var toRightBottom = GetManhattan(0, x2 + 1, 0, y1);

            if (toLeftBottom <= s)
            {
				upper += GetTriangleArea(s - toLeftBottom + 1);
            }
            if (toRightBottom <= s)
            {
				upper += GetTriangleArea(s - toRightBottom + 1);
            }

			var toLeftUpper = toLeftBottom + GetManhattan(x1 - 1, x1, y1, y2 + 1);
			var toRightUpper = toRightBottom + GetManhattan(x2 + 1, x2, y1, y2 + 1);

            if (toLeftUpper <= s)
            {
				upper += GetTriangleArea(s - toLeftUpper + 1);
            }
            if (toRightUpper <= s)
            {
				upper += GetTriangleArea(s - toRightUpper + 1);
            }

			var doubled = (s - toLeftUpper) + (s - toRightUpper) - (x2 - x1 - 1);

            if (doubled > 0)
            {
				var length = (doubled + 1) / 2;
				upper -= length * length;
			}
		}

		return lower + upper;
	}

	long GetManhattan(long x1, long x2, long y1, long y2)
    {
		return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }

	long GetTriangleArea(long length)
    {
		return length * (length + 1) / 2;
    }
}
