using System;
using NUnit.Framework;

[TestFixture]
public class HamiltonsTest
{
	[Test]
	public void Example0()
	{
		int N = 6;
		int L = 1000;
		int[] __expected = new int[] {
			174,
			325,
			60,
			839,
			248,
			437,
			398,
			965,
			806,
			658,
			985,
			969,
			319,
			100,
			149
		};
		int[] __result = new Hamiltons().construct(N, L);
		Assert.AreEqual(__expected, __result);
	}

}
