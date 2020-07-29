using System;
using NUnit.Framework;

[TestFixture]
public class SwapTheStringTest
{
	[Test]
	public void Example0()
	{
		string P = "cbexa";
		int A0 = 0;
		int X = 0;
		int Y = 0;
		int N = 5;
		int K = 2;
		long __expected = 2L;
		long __result = new SwapTheString().findNumberOfSwaps(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string P = "";
		int A0 = 5;
		int X = 2;
		int Y = 3;
		int N = 4;
		int K = 1;
		long __expected = 3L;
		long __result = new SwapTheString().findNumberOfSwaps(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string P = "b";
		int A0 = 1001;
		int X = 1001;
		int Y = 1001;
		int N = 5;
		int K = 2;
		long __expected = 3L;
		long __result = new SwapTheString().findNumberOfSwaps(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string P = "";
		int A0 = 9999;
		int X = 50000;
		int Y = 4797;
		int N = 6;
		int K = 3;
		long __expected = 2L;
		long __result = new SwapTheString().findNumberOfSwaps(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string P = "";
		int A0 = 3435;
		int X = 1000000000;
		int Y = 1812447358;
		int N = 7;
		int K = 2;
		long __expected = 5L;
		long __result = new SwapTheString().findNumberOfSwaps(P, A0, X, Y, N, K);
		Assert.AreEqual(__expected, __result);
	}

}
