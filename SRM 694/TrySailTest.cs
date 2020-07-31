using System;
using NUnit.Framework;

[TestFixture]
public class TrySailTest
{
	[Test]
	public void Example0()
	{
		int[] strength = new int[] {
			2,
			3,
			3
		};
		int __expected = 8;
		int __result = new TrySail().get(strength);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] strength = new int[] {
			7,
			3,
			5,
			2
		};
		int __expected = 17;
		int __result = new TrySail().get(strength);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] strength = new int[] {
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13
		};
		int __expected = 26;
		int __result = new TrySail().get(strength);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] strength = new int[] {
			114,
			51,
			4,
			191,
			9,
			81,
			0,
			89,
			3
		};
		int __expected = 470;
		int __result = new TrySail().get(strength);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] strength = new int[] {
			108,
			66,
			45,
			82,
			163,
			30,
			83,
			244,
			200,
			216,
			241,
			249,
			89,
			128,
			36,
			28,
			250,
			190,
			70,
			95,
			117,
			196,
			19,
			160,
			255,
			129,
			10,
			109,
			189,
			24,
			22,
			25,
			134,
			144,
			110,
			15,
			235,
			205,
			186,
			103,
			116,
			191,
			119,
			183,
			45,
			217,
			156,
			44,
			97,
			197
		};
		int __expected = 567;
		int __result = new TrySail().get(strength);
		Assert.AreEqual(__expected, __result);
	}

}
