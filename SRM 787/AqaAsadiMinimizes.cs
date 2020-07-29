using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

public class AqaAsadiMinimizes {
	public double getMin(int[] P, int B0, int X, int Y, int N)
    {
        var indexAndValues = Initialize(P, B0, X, Y, N);
        Array.Sort(indexAndValues);
        var min = double.MaxValue;

        for (int i = 0; i + 1 < indexAndValues.Length; i++)
        {
            var me = indexAndValues[i];
            var other = indexAndValues[i + 1];
            min = Math.Min(min, Math.Abs((double)(me.Value - other.Value) / (me.Index - other.Index)));
        }
        
        return min;
    }

    [StructLayout(LayoutKind.Auto)]
    struct IndexAndValue : IComparable<IndexAndValue>
    {
        public int Index;
        public int Value;

        public IndexAndValue(int index, int value)
        {
            Index = index;
            Value = value;
        }

        public int CompareTo(IndexAndValue other)
        {
            return Value - other.Value;
        }
    }

    private static IndexAndValue[] Initialize(int[] P, int B0, int X, int Y, int N)
    {
        var result = new IndexAndValue[N];
        for (int i = 0; i < result.Length; i++)
        {
            if (i < P.Length)
            {
                result[i] = new IndexAndValue(i, P[i]);
            }
            else if (i == P.Length)
            {
                result[i] = new IndexAndValue(i, B0);
            }
            else
            {
                result[i] = new IndexAndValue(i, (int)(((long)result[i - 1].Value * X + Y) % 1000000007));
            }
        }

        return result;
    }
}
