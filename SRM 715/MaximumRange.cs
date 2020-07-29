using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class MaximumRange {
	public int findMax(string s) {
		return Math.Max(s.Count(c => c == '+'), s.Count(c => c == '-'));
	}
}
