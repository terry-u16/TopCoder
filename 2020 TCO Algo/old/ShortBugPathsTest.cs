using System;
using NUnit.Framework;

[TestFixture]
public class ShortBugPathsTest
{
	[Test]
	public void Example0()
	{
		int N = 3;
		int[] D = new int[] {
			1
		};
		int J = 1;
		int __expected = 24;
		int __result = new ShortBugPaths().count(N, D, J);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int N = 123456789;
		int[] D = new int[] {
			0
		};
		int J = 3;
		int __expected = 643499475;
		int __result = new ShortBugPaths().count(N, D, J);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int N = 5;
		int[] D = new int[] {
			0,
			10,
			2
		};
		int J = 4;
		int __expected = 38281;
		int __result = new ShortBugPaths().count(N, D, J);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int N = 1000;
		int[] D = new int[] {
			0,
			1
		};
		int J = 1;
		int __expected = 4996000;
		int __result = new ShortBugPaths().count(N, D, J);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int N = 47;
		int[] D = new int[] {
			3
		};
		int J = 6;
		int __expected = 195354165;
		int __result = new ShortBugPaths().count(N, D, J);
		Assert.AreEqual(__expected, __result);
	}

}
