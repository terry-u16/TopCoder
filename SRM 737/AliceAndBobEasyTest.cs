using System;
using NUnit.Framework;

[TestFixture]
public class AliceAndBobEasyTest
{
	[Test]
	public void Example0()
	{
		int N = 1;
		int[] __expected = new int[] {
			737
		};
		int[] __result = new AliceAndBobEasy().make(N);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int N = 2;
		int[] __expected = new int[] {
			737,
			373
		};
		int[] __result = new AliceAndBobEasy().make(N);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int N = 3;
		int[] __expected = new int[] {
			3337,
			3373,
			3733
		};
		int[] __result = new AliceAndBobEasy().make(N);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserExample()
	{
		int N = 29;
		int[] __expected = new int[] {
			3337,
			3373,
			3733
		};
		int[] __result = new AliceAndBobEasy().make(N);
		Assert.AreEqual(__expected, __result);
	}
}
