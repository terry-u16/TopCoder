using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class OneHandSort {
	public int[] sortShelf(int[] target) {
		var operations = new List<int>();
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] != i)
            {
                var toMove = -1;
                for (int j = 0; j < target.Length; j++)
                {
                    if (target[j] == i)
                    {
                        toMove = j;
                        break;
                    }
                }
                operations.Add(i);
                operations.Add(toMove);
                operations.Add(target.Length);
                Swap(ref target[i], ref target[toMove]);
            }
        }

        return operations.ToArray();
    }

    void Swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}
