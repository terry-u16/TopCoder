using System;
using NUnit.Framework;

[TestFixture]
public class BearCavalryTest
{
	[Test]
	public void Example0()
	{
		int[] warriors = new int[] {
			5,
			8,
			4,
			8
		};
		int[] horses = new int[] {
			19,
			40,
			25,
			20
		};
		int __expected = 2;
		int __result = new BearCavalry().countAssignments(warriors, horses);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] warriors = new int[] {
			1,
			1
		};
		int[] horses = new int[] {
			1,
			1
		};
		int __expected = 0;
		int __result = new BearCavalry().countAssignments(warriors, horses);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] warriors = new int[] {
			10,
			2,
			10
		};
		int[] horses = new int[] {
			100,
			150,
			200
		};
		int __expected = 3;
		int __result = new BearCavalry().countAssignments(warriors, horses);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] warriors = new int[] {
			10,
			20
		};
		int[] horses = new int[] {
			1,
			3
		};
		int __expected = 1;
		int __result = new BearCavalry().countAssignments(warriors, horses);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] warriors = new int[] {
			20,
			20,
			25,
			23,
			24,
			24,
			21
		};
		int[] horses = new int[] {
			20,
			25,
			25,
			20,
			25,
			23,
			20
		};
		int __expected = 0;
		int __result = new BearCavalry().countAssignments(warriors, horses);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example5()
	{
		int[] warriors = new int[] {
			970,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800,
			800
		};
		int[] horses = new int[] {
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000
		};
		int __expected = 318608048;
		int __result = new BearCavalry().countAssignments(warriors, horses);
		Assert.AreEqual(__expected, __result);
	}

}
