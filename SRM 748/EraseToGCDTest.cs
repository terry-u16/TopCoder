using System;
using NUnit.Framework;

[TestFixture]
public class EraseToGCDTest
{
	[Test]
	public void Example0()
	{
		int[] S = new int[] {
			6,
			4,
			30,
			90,
			66
		};
		int goal = 2;
		int __expected = 15;
		int __result = new EraseToGCD().countWays(S, goal);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] S = new int[] {
			8,
			8,
			8
		};
		int goal = 4;
		int __expected = 0;
		int __result = new EraseToGCD().countWays(S, goal);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] S = new int[] {
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10
		};
		int goal = 1;
		int __expected = 983;
		int __result = new EraseToGCD().countWays(S, goal);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] S = new int[] {
			2,
			2,
			2,
			2,
			2
		};
		int goal = 2;
		int __expected = 31;
		int __result = new EraseToGCD().countWays(S, goal);
		Assert.AreEqual(__expected, __result);
	}

}
