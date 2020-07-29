using System;
using NUnit.Framework;

[TestFixture]
public class RailwayMasterTest
{
	[Test]
	public void Example0()
	{
		int N = 3;
		int M = 3;
		int K = 3;
		int[] a = new int[] {
			0,
			1,
			2
		};
		int[] b = new int[] {
			1,
			2,
			0
		};
		int[] v = new int[] {
			224,
			258,
			239
		};
		int __expected = 258;
		int __result = new RailwayMaster().maxProfit(N, M, K, a, b, v);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int N = 4;
		int M = 6;
		int K = 2;
		int[] a = new int[] {
			0,
			0,
			0,
			1,
			1,
			2
		};
		int[] b = new int[] {
			1,
			2,
			3,
			2,
			3,
			3
		};
		int[] v = new int[] {
			500,
			900,
			600,
			700,
			800,
			100
		};
		int __expected = 1700;
		int __result = new RailwayMaster().maxProfit(N, M, K, a, b, v);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int N = 5;
		int M = 7;
		int K = 1;
		int[] a = new int[] {
			0,
			1,
			2,
			3,
			3,
			0,
			1
		};
		int[] b = new int[] {
			1,
			2,
			3,
			4,
			0,
			2,
			3
		};
		int[] v = new int[] {
			100,
			100,
			100,
			900,
			100,
			100,
			100
		};
		int __expected = 100;
		int __result = new RailwayMaster().maxProfit(N, M, K, a, b, v);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int N = 5;
		int M = 7;
		int K = 3;
		int[] a = new int[] {
			0,
			0,
			0,
			0,
			1,
			2,
			3
		};
		int[] b = new int[] {
			1,
			1,
			1,
			1,
			2,
			3,
			4
		};
		int[] v = new int[] {
			926,
			815,
			777,
			946,
			928,
			634,
			999
		};
		int __expected = 2687;
		int __result = new RailwayMaster().maxProfit(N, M, K, a, b, v);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int N = 5;
		int M = 7;
		int K = 6;
		int[] a = new int[] {
			0,
			1,
			2,
			3,
			4,
			1,
			3
		};
		int[] b = new int[] {
			1,
			2,
			3,
			4,
			0,
			4,
			0
		};
		int[] v = new int[] {
			118,
			124,
			356,
			480,
			625,
			767,
			911
		};
		int __expected = 2303;
		int __result = new RailwayMaster().maxProfit(N, M, K, a, b, v);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example5()
	{
		int N = 10;
		int M = 15;
		int K = 3;
		int[] a = new int[] {
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			0,
			1,
			2,
			3,
			4
		};
		int[] b = new int[] {
			1,
			2,
			3,
			4,
			0,
			6,
			7,
			8,
			9,
			5,
			5,
			6,
			7,
			8,
			9
		};
		int[] v = new int[] {
			220284,
			869120,
			787788,
			980412,
			133333,
			314159,
			256312,
			192916,
			298575,
			931110,
			175353,
			926778,
			201513,
			202729,
			155136
		};
		int __expected = 2838300;
		int __result = new RailwayMaster().maxProfit(N, M, K, a, b, v);
		Assert.AreEqual(__expected, __result);
	}

}
