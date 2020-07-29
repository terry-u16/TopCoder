using System;
using NUnit.Framework;

[TestFixture]
public class MaximumRangeTest
{
	[Test]
	public void Example0()
	{
		string s = "+++++++";
		int __expected = 7;
		int __result = new MaximumRange().findMax(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string s = "+--+--+";
		int __expected = 4;
		int __result = new MaximumRange().findMax(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string s = "++++--------";
		int __expected = 8;
		int __result = new MaximumRange().findMax(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string s = "-+-+-+-+-+-+";
		int __expected = 6;
		int __result = new MaximumRange().findMax(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		string s = "+";
		int __expected = 1;
		int __result = new MaximumRange().findMax(s);
		Assert.AreEqual(__expected, __result);
	}

}
