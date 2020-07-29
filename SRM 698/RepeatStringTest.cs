using System;
using NUnit.Framework;

[TestFixture]
public class RepeatStringTest
{
	[Test]
	public void Example0()
	{
		string s = "aba";
		int __expected = 1;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string s = "adam";
		int __expected = 1;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string s = "x";
		int __expected = 1;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string s = "aaabbbaaaccc";
		int __expected = 3;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string s = "repeatstring";
		int __expected = 6;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example5()
	{
		string s = "aaaaaaaaaaaaaaaaaaaa";
		int __expected = 0;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest1()
	{
		string s = "abcabcxx";
		int __expected = 2;
		int __result = new RepeatString().minimalModify(s);
		Assert.AreEqual(__expected, __result);
	}

}
