using System;
using NUnit.Framework;

[TestFixture]
public class PerfectSquaresTest
{
	[Test]
	public void Example0()
	{
		long minimum = 1L;
		long maximum = 10L;
		int maxN = 3;
		int __expected = 4;
		int __result = new PerfectSquares().countRange(minimum, maximum, maxN);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		long minimum = 1L;
		long maximum = 20L;
		int maxN = 30;
		int __expected = 5;
		int __result = new PerfectSquares().countRange(minimum, maximum, maxN);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		long minimum = 100L;
		long maximum = 200L;
		int maxN = 2;
		int __expected = 5;
		int __result = new PerfectSquares().countRange(minimum, maximum, maxN);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest()
	{
		long minimum = 1L;
		long maximum = 100000000000L;
		int maxN = 30;
		int __expected = -1;
		int __result = new PerfectSquares().countRange(minimum, maximum, maxN);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest2()
	{
		long minimum = 1L;
		long maximum = 64L;
		int maxN = 6;
		int __expected = 11;
		int __result = new PerfectSquares().countRange(minimum, maximum, maxN);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest3()
	{
		long minimum = 2L;
		long maximum = 64L;
		int maxN = 6;
		int __expected = 10;
		int __result = new PerfectSquares().countRange(minimum, maximum, maxN);
		Assert.AreEqual(__expected, __result);
	}
}
