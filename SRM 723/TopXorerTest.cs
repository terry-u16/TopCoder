using System;
using NUnit.Framework;

[TestFixture]
public class TopXorerTest
{
	[Test]
	public void Example0()
	{
		int[] x = new int[] {
			2,
			2,
			2
		};
		int __expected = 3;
		int __result = new TopXorer().maximalRating(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] x = new int[] {
			1,
			2,
			4,
			8,
			16
		};
		int __expected = 31;
		int __result = new TopXorer().maximalRating(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] x = new int[] {
			1024,
			1024
		};
		int __expected = 2047;
		int __result = new TopXorer().maximalRating(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] x = new int[] {
			7,
			4,
			12,
			33,
			6,
			8,
			3,
			1
		};
		int __expected = 47;
		int __result = new TopXorer().maximalRating(x);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] x = new int[] {
			0
		};
		int __expected = 0;
		int __result = new TopXorer().maximalRating(x);
		Assert.AreEqual(__expected, __result);
	}

}
