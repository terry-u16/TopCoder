using System;
using NUnit.Framework;

[TestFixture]
public class MagicNumberThreeTest
{
	[Test]
	public void Example0()
	{
		string s = "132";
		int __expected = 3;
		int __result = new MagicNumberThree().countSubsequences(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string s = "9";
		int __expected = 1;
		int __result = new MagicNumberThree().countSubsequences(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string s = "333";
		int __expected = 7;
		int __result = new MagicNumberThree().countSubsequences(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string s = "123456";
		int __expected = 23;
		int __result = new MagicNumberThree().countSubsequences(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string s = "00";
		int __expected = 3;
		int __result = new MagicNumberThree().countSubsequences(s);
		Assert.AreEqual(__expected, __result);
	}

}
