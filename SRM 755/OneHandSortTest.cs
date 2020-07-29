using System;
using NUnit.Framework;

[TestFixture]
public class OneHandSortTest
{
	[Test]
	public void Example0()
	{
		int[] target = new int[] {
			0,
			1,
			2
		};
		int[] __expected = new int[] {
		};
		int[] __result = new OneHandSort().sortShelf(target);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] target = new int[] {
			1,
			2,
			3,
			0
		};
		int[] __expected = new int[] {
			2,
			1,
			0,
			3,
			4
		};
		int[] __result = new OneHandSort().sortShelf(target);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] target = new int[] {
			1,
			0,
			3,
			2
		};
		int[] __expected = new int[] {
			0,
			1,
			4,
			2,
			3,
			4
		};
		int[] __result = new OneHandSort().sortShelf(target);
		Assert.AreEqual(__expected, __result);
	}

}
