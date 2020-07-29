using System;
using NUnit.Framework;

[TestFixture]
public class MaximizingGCDTest
{
	[Test]
	public void Example0()
	{
		int[] A = new int[] {
			5,
			4,
			13,
			2
		};
		int __expected = 6;
		int __result = new MaximizingGCD().maximumGCDPairing(A);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] A = new int[] {
			26,
			23
		};
		int __expected = 49;
		int __result = new MaximizingGCD().maximumGCDPairing(A);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] A = new int[] {
			100,
			200,
			300,
			500,
			1100,
			700
		};
		int __expected = 100;
		int __result = new MaximizingGCD().maximumGCDPairing(A);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] A = new int[] {
			46,
			78,
			133,
			92,
			1,
			23,
			29,
			67,
			43,
			111,
			3908,
			276,
			13,
			359,
			20,
			21
		};
		int __expected = 4;
		int __result = new MaximizingGCD().maximumGCDPairing(A);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int[] A = new int[] {
			16,
			32,
			64,
			128,
			256,
			512,
			1024,
			2048,
			4096,
			8192,
			16384,
			32768,
			65536,
			131072,
			262144,
			524288,
			1048576,
			2097152,
			4194304,
			8388608
		};
		int __expected = 16400;
		int __result = new MaximizingGCD().maximumGCDPairing(A);
		Assert.AreEqual(__expected, __result);
	}

}
