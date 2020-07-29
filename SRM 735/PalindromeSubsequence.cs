using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class PalindromeSubsequence {
    public int[] optimalPartition(string s)
    {
        if (IsPalindrome(s))
        {
            return Enumerable.Repeat(1, s.Length).ToArray();
        }
        else
        {
            return s.Select(c => c == 'a' ? 1 : 2).ToArray();
        }
    }

	bool IsPalindrome(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}
