using System;
using NUnit.Framework;

[TestFixture]
public class AqaAsadiMinimizesTest
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
		int[] P = new int[] {
			11,
			0,
			30,
			20,
			1000
		};
		int B0 = 0;
		int X = 0;
		int Y = 0;
		int N = 5;
		double __expected = 3.0;
		double __result = new AqaAsadiMinimizes().getMin(P, B0, X, Y, N);
		AssertTcEqualTo(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] P = new int[] {
			47,
			1,
			10,
			3,
			2
		};
		int B0 = 0;
		int X = 0;
		int Y = 0;
		int N = 5;
		double __expected = 0.3333333333333333;
		double __result = new AqaAsadiMinimizes().getMin(P, B0, X, Y, N);
		AssertTcEqualTo(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] P = new int[] {
			123456
		};
		int B0 = 234567890;
		int X = 345678;
		int Y = 456789;
		int N = 10;
		double __expected = 8333191.571428572;
		double __result = new AqaAsadiMinimizes().getMin(P, B0, X, Y, N);
		AssertTcEqualTo(__expected, __result);
	}

}
