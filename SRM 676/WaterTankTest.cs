using System;
using NUnit.Framework;

[TestFixture]
public class WaterTankTest
{
	class TcDoubleEqualityComparer : System.Collections.Generic.IEqualityComparer<double>
	{
		public bool Equals(double x, double y)
		{
			double eps = 1e-9;
			return
				!double.IsNaN(x) && !double.IsNaN(y)
				&& Math.Abs(x - y) <= eps*Math.Max(1.0, Math.Min(Math.Abs(x), Math.Abs(y)));
		}

		public int GetHashCode(double obj)
		{
			// Not relevant
			throw new NotImplementedException();
		}
	}

	private static void AssertTcEqualTo<T>(T expected, T actual)
	{
		Assert.That(actual, Is.EqualTo(expected).Using(new TcDoubleEqualityComparer()));
	}

	[Test]
	public void Example0()
	{
		int[] t = new int[] {
			3,
			3
		};
		int[] x = new int[] {
			1,
			2
		};
		int C = 3;
		double __expected = 0.9999999999999999;
		double __result = new WaterTank().minOutputRate(t, x, C);
		AssertTcEqualTo(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] t = new int[] {
			1,
			2,
			3,
			4,
			5
		};
		int[] x = new int[] {
			5,
			4,
			3,
			2,
			1
		};
		int C = 10;
		double __expected = 1.9999999999999996;
		double __result = new WaterTank().minOutputRate(t, x, C);
		AssertTcEqualTo(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] t = new int[] {
			5949,
			3198,
			376,
			3592,
			4019,
			3481,
			5609,
			3840,
			6092,
			4059
		};
		int[] x = new int[] {
			29,
			38,
			96,
			84,
			10,
			2,
			39,
			27,
			76,
			94
		};
		int C = 1000000000;
		double __expected = 0.0;
		double __result = new WaterTank().minOutputRate(t, x, C);
		AssertTcEqualTo(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] t = new int[] {
			9,
			3,
			4,
			8,
			1,
			2,
			5,
			7,
			6
		};
		int[] x = new int[] {
			123,
			456,
			789,
			1011,
			1213,
			1415,
			1617,
			1819,
			2021
		};
		int C = 11;
		double __expected = 2019.1666666666665;
		double __result = new WaterTank().minOutputRate(t, x, C);
		AssertTcEqualTo(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] t = new int[] {
			100
		};
		int[] x = new int[] {
			1000
		};
		int C = 12345;
		double __expected = 876.55;
		double __result = new WaterTank().minOutputRate(t, x, C);
		AssertTcEqualTo(__expected, __result);
	}

}
