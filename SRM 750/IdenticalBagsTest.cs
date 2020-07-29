using System;
using NUnit.Framework;

[TestFixture]
public class IdenticalBagsTest
{
	[Test]
	public void Example0()
	{
		long[] candy = new long[] {
			10L,
			11L,
			12L
		};
		long bagSize = 3L;
		long __expected = 10L;
		long __result = new IdenticalBags().makeBags(candy, bagSize);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		long[] candy = new long[] {
			10L,
			11L,
			12L,
			1L,
			2L,
			3L
		};
		long bagSize = 3L;
		long __expected = 10L;
		long __result = new IdenticalBags().makeBags(candy, bagSize);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		long[] candy = new long[] {
			100L
		};
		long bagSize = 7L;
		long __expected = 14L;
		long __result = new IdenticalBags().makeBags(candy, bagSize);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		long[] candy = new long[] {
			10000000000L,
			20000000000L,
			30000000000L
		};
		long bagSize = 6L;
		long __expected = 10000000000L;
		long __result = new IdenticalBags().makeBags(candy, bagSize);
		Assert.AreEqual(__expected, __result);
	}

}
