using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class SwapTheString {
	public long findNumberOfSwaps(string P, int A0, int X, int Y, int N, int K) {
		string s = Initialize(P, A0, X, Y, N);
        long count = 0;

        for (int begin = 0; begin < K; begin++)
        {
            var bit = new BinaryIndexedTree(26);
            for (int i = begin; i < s.Length; i += K)
            {
                var c = s[i] - 'a';
                bit[c]++;
                count += bit.Sum(c);
            }
        }

		return count;
	}

	string Initialize(string P, int A0, int X, int Y, int N)
    {
		var a = new long[N];
		a[0] = A0;
        for (int i = 1; i < a.Length; i++)
        {
			a[i] = (a[i - 1] * X + Y) % 1812447359L;
		}

		var builder = new StringBuilder(P);
        for (int i = P.Length; i < N; i++)
        {
			builder.Append((char)(a[i] % 26 + 'a'));
        }

		return builder.ToString();
    }

    public class BinaryIndexedTree
    {
        long[] _data;
        public readonly int Length;

        public BinaryIndexedTree(int length)
        {
            _data = new long[length + 1];   // 内部的には1-indexedにする
            Length = length;
        }

        public long this[int index]
        {
            get
            {
                return Sum(index, index + 1);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                AddAt(index, value - this[index]);
            }
        }

        /// <summary>
        /// BITの<c>index</c>番目の要素に<c>n</c>を加算します。
        /// </summary>
        /// <param name="index">加算するインデックス（0-indexed）</param>
        /// <param name="value">加算する数</param>
        public void AddAt(int index, long value)
        {
            unchecked
            {
                if ((uint)index >= (uint)Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            index++;  // 1-indexedにする

            while (index <= Length)
            {
                _data[index] += value;
                index += index & -index;    // LSBの加算
            }
        }

        /// <summary>
        /// [0, <c>end</c>)の部分和を返します。
        /// </summary>
        /// <param name="end">部分和を求める半開区間の終了インデックス</param>
        /// <returns>区間の部分和</returns>
        public long Sum(int end)
        {
            unchecked
            {
                if ((uint)end >= (uint)_data.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            long sum = 0;
            while (end > 0)
            {
                sum += _data[end];
                end -= end & -end;    // LSBの減算
            }
            return sum;
        }

        /// <summary>
        /// [<c>start</c>, <c>end</c>)の部分和を返します。
        /// </summary>
        /// <param name="start">部分和を求める半開区間の開始インデックス</param>
        /// <param name="end">部分和を求める半開区間の終了インデックス</param>
        /// <returns>区間の部分和</returns>
        public long Sum(int start, int end)
        {
            return Sum(end) - Sum(start);
        }
    }
}
