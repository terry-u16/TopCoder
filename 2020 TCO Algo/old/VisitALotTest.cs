using System;
using NUnit.Framework;

[TestFixture]
public class VisitALotTest
{
	[Test]
	public void Example0()
	{
		int R = 2;
		int C = 3;
		int[] obsr = new int[] {
		};
		int[] obsc = new int[] {
		};
		string __expected = "SENE";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int R = 6;
		int C = 5;
		int[] obsr = new int[] {
			1,
			1,
			4
		};
		int[] obsc = new int[] {
			1,
			3,
			1
		};
		string __expected = "SSEESWWSSEENEE";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int R = 7;
		int C = 8;
		int[] obsr = new int[] {
		};
		int[] obsc = new int[] {
		};
		string __expected = "EEEEEEESWWWWWWWSEEEEEEESWWWWWWWSEEEEEEESWWWWWWWSEEEEEEE";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest()
	{
		int R = 6;
		int C = 5;
		int[] obsr = new int[] {
			4, 3, 4
		};
		int[] obsc = new int[] {
			1, 2, 3
		};
		string __expected = "SSEESWWSSEENEE";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest2()
	{
		int R = 3;
		int C = 3;
		int[] obsr = new int[] {
			1
		};
		int[] obsc = new int[] {
			1
		};
		string __expected = "SSEE";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest3()
	{
		int R = 2;
		int C = 2;
		int[] obsr = new int[] {
		};
		int[] obsc = new int[] {
		};
		string __expected = "S";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest4()
	{
		int R = 4;
		int C = 5;
		int[] obsr = new int[] {
			2, 1, 2
		};
		int[] obsc = new int[] {
			1, 2, 3
		};
		string __expected = "SSSEEEENN";
		string __result = new VisitALot().travel(R, C, obsr, obsc);
		Assert.AreEqual(__expected, __result);
	}

}
