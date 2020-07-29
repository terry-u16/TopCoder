using System;
using NUnit.Framework;

[TestFixture]
public class MultiplicationTable2Test
{
	[Test]
	public void Example0()
	{
		int[] table = new int[] {
			1,
			1,
			2,
			3,
			1,
			0,
			3,
			2,
			2,
			0,
			1,
			3,
			1,
			2,
			3,
			0
		};
		int __expected = 2;
		int __result = new MultiplicationTable2().minimalGoodSet(table);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int[] table = new int[] {
			0,
			1,
			2,
			3,
			1,
			2,
			3,
			0,
			2,
			3,
			0,
			1,
			3,
			0,
			1,
			2
		};
		int __expected = 1;
		int __result = new MultiplicationTable2().minimalGoodSet(table);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int[] table = new int[] {
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			3,
			3,
			3,
			3,
			0,
			0,
			0,
			0
		};
		int __expected = 4;
		int __result = new MultiplicationTable2().minimalGoodSet(table);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int[] table = new int[] {
			0
		};
		int __expected = 1;
		int __result = new MultiplicationTable2().minimalGoodSet(table);
		Assert.AreEqual(__expected, __result);
	}

}
