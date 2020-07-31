using System;
using NUnit.Framework;

[TestFixture]
public class ParenthesisRemovalTest
{
	[Test]
	public void Example0()
	{
		string s = "()()()()()";
		int __expected = 1;
		int __result = new ParenthesisRemoval().countWays(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string s = "(((())))";
		int __expected = 24;
		int __result = new ParenthesisRemoval().countWays(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string s = "((()()()))";
		int __expected = 54;
		int __result = new ParenthesisRemoval().countWays(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string s = "(())(())(())";
		int __expected = 8;
		int __result = new ParenthesisRemoval().countWays(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string s = "((((())((((((((((()((((((()))))())))))()))))))))))";
		int __expected = 948334170;
		int __result = new ParenthesisRemoval().countWays(s);
		Assert.AreEqual(__expected, __result);
	}

}
