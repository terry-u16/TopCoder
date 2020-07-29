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
            _data = new long[length + 1];   // �����I�ɂ�1-indexed�ɂ���
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
        /// BIT��<c>index</c>�Ԗڂ̗v�f��<c>n</c>�����Z���܂��B
        /// </summary>
        /// <param name="index">���Z����C���f�b�N�X�i0-indexed�j</param>
        /// <param name="value">���Z���鐔</param>
        public void AddAt(int index, long value)
        {
            unchecked
            {
                if ((uint)index >= (uint)Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            index++;  // 1-indexed�ɂ���

            while (index <= Length)
            {
                _data[index] += value;
                index += index & -index;    // LSB�̉��Z
            }
        }

        /// <summary>
        /// [0, <c>end</c>)�̕����a��Ԃ��܂��B
        /// </summary>
        /// <param name="end">�����a�����߂锼�J��Ԃ̏I���C���f�b�N�X</param>
        /// <returns>��Ԃ̕����a</returns>
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
                end -= end & -end;    // LSB�̌��Z
            }
            return sum;
        }

        /// <summary>
        /// [<c>start</c>, <c>end</c>)�̕����a��Ԃ��܂��B
        /// </summary>
        /// <param name="start">�����a�����߂锼�J��Ԃ̊J�n�C���f�b�N�X</param>
        /// <param name="end">�����a�����߂锼�J��Ԃ̏I���C���f�b�N�X</param>
        /// <returns>��Ԃ̕����a</returns>
        public long Sum(int start, int end)
        {
            return Sum(end) - Sum(start);
        }
    }
}
