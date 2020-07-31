using System;
using NUnit.Framework;

[TestFixture]
public class AlmostFibonacciKnapsackTest
{
	[Test]
	public void Example0()
	{
		long x = 148L;
		int[] __expected = new int[] {
			6,
			10,
			8,
			5
		};
		int[] __result = new AlmostFibonacciKnapsack().getIndices(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		long x = 2L;
		int[] __expected = new int[] {
			1
		};
		int[] __result = new AlmostFibonacciKnapsack().getIndices(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		long x = 13L;
		int[] __expected = new int[] {
			2,
			3,
			4
		};
		int[] __result = new AlmostFibonacciKnapsack().getIndices(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		long x = 3L;
		int[] __expected = new int[] {
			2
		};
		int[] __result = new AlmostFibonacciKnapsack().getIndices(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		long x = 86267769395L;
		int[] __expected = new int[] {
			3,
			14,
			15,
			9,
			26,
			53,
			5,
			8
		};
		int[] __result = new AlmostFibonacciKnapsack().getIndices(x);
		Assert.AreEqual(__expected, __result);
	}

}
