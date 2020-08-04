using System;
using NUnit.Framework;

[TestFixture]
public class RectangularObstacleTest
{
	[Test]
	public void Example0()
	{
		int x1 = -5;
		int x2 = 5;
		int y1 = 3;
		int y2 = 3;
		int s = 2;
		long __expected = 13L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		int x1 = -5;
		int x2 = 5;
		int y1 = 3;
		int y2 = 3;
		int s = 3;
		long __expected = 24L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		int x1 = -4;
		int x2 = 1;
		int y1 = 1;
		int y2 = 2;
		int s = 6;
		long __expected = 61L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		int x1 = 0;
		int x2 = 0;
		int y1 = 1;
		int y2 = 1;
		int s = 4;
		long __expected = 38L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		int x1 = -100;
		int x2 = 100;
		int y1 = 42;
		int y2 = 47;
		int s = 0;
		long __expected = 1L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Handmaid1()
	{
		int x1 = -2;
		int x2 = 2;
		int y1 = 1;
		int y2 = 2;
		int s = 10;
		long __expected = 193L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Handmaid2()
	{
		int x1 = -2;
		int x2 = 2;
		int y1 = 2;
		int y2 = 2;
		int s = 10;
		long __expected = 198L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Handmaid3()
	{
		int x1 = 1;
		int x2 = 1;
		int y1 = 3;
		int y2 = 3;
		int s = 4;
		long __expected = 40L;
		long __result = new RectangularObstacle().countReachable(x1, x2, y1, y2, s);
		Assert.AreEqual(__expected, __result);
	}
}
