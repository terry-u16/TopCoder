using System;
using NUnit.Framework;

[TestFixture]
public class PalindromeSubsequenceTest
{
	[Test]
	public void Example0()
	{
		string s = "bababba";
		int[] __expected = new int[] {
			1,
			2,
			2,
			1,
			2,
			1,
			2
		};
		int[] __result = new PalindromeSubsequence().optimalPartition(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		string s = "abba";
		int[] __expected = new int[] {
			1,
			1,
			1,
			1
		};
		int[] __result = new PalindromeSubsequence().optimalPartition(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		string s = "b";
		int[] __expected = new int[] {
			1
		};
		int[] __result = new PalindromeSubsequence().optimalPartition(s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		string s = "babb";
		int[] __expected = new int[] {
			1,
			1,
			1,
			2
		};
		int[] __result = new PalindromeSubsequence().optimalPartition(s);
		Assert.AreEqual(__expected, __result);
	}

}
