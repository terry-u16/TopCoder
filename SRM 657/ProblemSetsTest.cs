using System;
using NUnit.Framework;

[TestFixture]
public class ProblemSetsTest
{
	[Test]
	public void Example0()
	{
		long E = 2L;
		long EM = 2L;
		long M = 1L;
		long MH = 2L;
		long H = 2L;
		long __expected = 3L;
		long __result = new ProblemSets().maxSets(E, EM, M, MH, H);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example1()
	{
		long E = 100L;
		long EM = 100L;
		long M = 100L;
		long MH = 0L;
		long H = 0L;
		long __expected = 0L;
		long __result = new ProblemSets().maxSets(E, EM, M, MH, H);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example2()
	{
		long E = 657L;
		long EM = 657L;
		long M = 657L;
		long MH = 657L;
		long H = 657L;
		long __expected = 1095L;
		long __result = new ProblemSets().maxSets(E, EM, M, MH, H);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example3()
	{
		long E = 1L;
		long EM = 2L;
		long M = 3L;
		long MH = 4L;
		long H = 5L;
		long __expected = 3L;
		long __result = new ProblemSets().maxSets(E, EM, M, MH, H);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void Example4()
	{
		long E = 1000000000000000000L;
		long EM = 1000000000000000000L;
		long M = 1000000000000000000L;
		long MH = 1000000000000000000L;
		long H = 1000000000000000000L;
		long __expected = 1666666666666666666L;
		long __result = new ProblemSets().maxSets(E, EM, M, MH, H);
		Assert.AreEqual(__expected, __result);
	}

	[Test]
	public void UserTest1()
	{
		long E = 2;
		long EM = 0;
		long M = 2;
		long MH = 0;
		long H = 2;
		long __expected = 2;
		long __result = new ProblemSets().maxSets(E, EM, M, MH, H);
		Assert.AreEqual(__expected, __result);
	}

}
