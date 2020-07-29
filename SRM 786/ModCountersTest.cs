using System;
using NUnit.Framework;

[TestFixture]
public class ModCountersTest
{
	[Test]
	public void Example0()
	{
		int[] P = new int[] {
			0,
			511
		};
		int A0 = 0;
		int X = 0;
		int Y = 0;
		int N = 2;
		int K = 1;
		int __expected = 256;
		int __result = new ModCounters().findExpectedSum(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] P = new int[] {
			0
		};
		int A0 = 1001;
		int X = 1001;
		int Y = 1001;
		int N = 2;
		int K = 2;
		int __expected = 508;
		int __result = new ModCounters().findExpectedSum(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] P = new int[] {
		};
		int A0 = 3583;
		int X = 1000;
		int Y = 1812447358;
		int N = 2;
		int K = 2;
		int __expected = 152;
		int __result = new ModCounters().findExpectedSum(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] P = new int[] {
			100,
			101
		};
		int A0 = 5000;
		int X = 50000;
		int Y = 100000;
		int N = 1000;
		int K = 1000;
		int __expected = 856925612;
		int __result = new ModCounters().findExpectedSum(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] P = new int[] {
		};
		int A0 = 100000000;
		int X = 100000000;
		int Y = 100000000;
		int N = 10;
		int K = 1000;
		int __expected = 454731206;
		int __result = new ModCounters().findExpectedSum(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example5()
	{
		int[] P = new int[] {
		};
		int A0 = 501296088;
		int X = 234548363;
		int Y = 703491623;
		int N = 2000000;
		int K = 1894643;
		int __expected = 804222535;
		int __result = new ModCounters().findExpectedSum(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

}
