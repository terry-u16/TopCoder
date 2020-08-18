using System;
using NUnit.Framework;

[TestFixture]
public class LexicographicPartitionTest
{
	[Test]
	public void Example0()
	{
		int n = 3;
		int[] Aprefix = new int[] {
			3,
			-7,
			8
		};
		int seed = 1;
		int Arange = 1;
		int[] __expected = new int[] {
			2,
			1,
			2
		};
		int[] __result = new LexicographicPartition().positiveSum(n, Aprefix, seed, Arange);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int n = 5;
		int[] Aprefix = new int[] {
			0,
			1,
			0,
			1,
			2
		};
		int seed = 42;
		int Arange = 47;
		int[] __expected = new int[] {
			3,
			2,
			2,
			1
		};
		int[] __result = new LexicographicPartition().positiveSum(n, Aprefix, seed, Arange);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int n = 5;
		int[] Aprefix = new int[] {
			-1,
			2,
			-3,
			4,
			-5
		};
		int seed = 777;
		int Arange = 4747;
		int[] __expected = new int[] {
			-1
		};
		int[] __result = new LexicographicPartition().positiveSum(n, Aprefix, seed, Arange);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int n = 1;
		int[] Aprefix = new int[] {
			0
		};
		int seed = 12;
		int Arange = 34;
		int[] __expected = new int[] {
			-1
		};
		int[] __result = new LexicographicPartition().positiveSum(n, Aprefix, seed, Arange);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int n = 10;
		int[] Aprefix = new int[] {
			4,
			-7,
			4,
			-7
		};
		int seed = 123456789;
		int Arange = 5447;
		int[] __expected = new int[] {
			6,
			1,
			5,
			1,
			1,
			1,
			1
		};
		int[] __result = new LexicographicPartition().positiveSum(n, Aprefix, seed, Arange);
		Assert.AreEqual(__expected, __result);
	}


	[Test]
	public void UserTest1()
	{
		int n = 1;
		int[] Aprefix = new int[] {
			1
		};
		int seed = 1;
		int Arange = 1;
		int[] __expected = new int[] {
			1,
			1
		};
		int[] __result = new LexicographicPartition().positiveSum(n, Aprefix, seed, Arange);
		Assert.AreEqual(__expected, __result);
	}
}
