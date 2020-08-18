using System;
using NUnit.Framework;

[TestFixture]
public class OrderOfOperationsTest
{
	[Test]
	public void Example0()
	{
		string[] s = new string[] {
			"111",
			"001",
			"010"
		};
		int __expected = 3;
		int __result = new OrderOfOperations().minTime(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string[] s = new string[] {
			"11101",
			"00111",
			"10101",
			"00000",
			"11000"
		};
		int __expected = 9;
		int __result = new OrderOfOperations().minTime(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string[] s = new string[] {
			"11111111111111111111"
		};
		int __expected = 400;
		int __result = new OrderOfOperations().minTime(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string[] s = new string[] {
			"1000",
			"1100",
			"1110"
		};
		int __expected = 3;
		int __result = new OrderOfOperations().minTime(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string[] s = new string[] {
			"111",
			"111",
			"110",
			"100"
		};
		int __expected = 3;
		int __result = new OrderOfOperations().minTime(s);
		Assert.AreEqual(__expected, __result);
	}

}
