using System;
using NUnit.Framework;

[TestFixture]
public class HorseRacingTest
{
	[Test]
	public void Example0()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "AC";
		int __expected = 2;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "CA";
		int __expected = 2;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "Cb";
		int __expected = 1;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "X";
		int __expected = 0;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "HelloTopcoder";
		int __expected = -1;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example5()
	{
		string[] races = new string[] {
			"a",
			"b",
			"c",
			"d",
			"e",
			"f"
		};
		string ticket = "bead";
		int __expected = 4;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void MyTest1()
	{
		string[] races = new string[] {
			"A",
			"C"
		};
		string ticket = "AH";
		int __expected = -1;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void MyTest2()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "Abd";
		int __expected = -1;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void MyTest3()
	{
		string[] races = new string[] {
			"AbX",
			"CdeF"
		};
		string ticket = "AA";
		int __expected = -1;
		int __result = new HorseRacing().validateTicket(races, ticket);
		Assert.AreEqual(__expected, __result);
	}
}
