using System;
using NUnit.Framework;

[TestFixture]
public class HalvingTest
{
	[Test]
	public void Example0()
	{
		int[] a = new int[] {
			11,
			4
		};
		int __expected = 3;
		int __result = new Halving().minSteps(a);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] a = new int[] {
			1000000000,
			1000000000,
			1000000000,
			1000000000
		};
		int __expected = 0;
		int __result = new Halving().minSteps(a);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] a = new int[] {
			1,
			2,
			3,
			4,
			5,
			6,
			7
		};
		int __expected = 10;
		int __result = new Halving().minSteps(a);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] a = new int[] {
			13,
			13,
			7,
			11,
			13,
			11
		};
		int __expected = 11;
		int __result = new Halving().minSteps(a);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] a = new int[] {
			1,
			1
		};
		int __expected = 0;
		int __result = new Halving().minSteps(a);
		Assert.AreEqual(__expected, __result);
	}

}
