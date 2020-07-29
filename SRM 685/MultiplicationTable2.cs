using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class MultiplicationTable2 {
	public int minimalGoodSet(int[] table) {
		int minSet = int.MaxValue;
        var n = GetN(table.Length);

        for (int start = 0; start < n; start++)
        {
			var included = new bool[n];
			included[start] = true;

			var queue = new Queue<int>();
			if (table[start + n * start] == start)
            {
				minSet = 1;
				break;
            }
            else
            {
				queue.Enqueue(table[start + n * start]);
                included[table[start + n * start]] = true;

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    for (int i = 0; i < n; i++)
                    {
                        if (included[i])
                        {
                            var a = table[i + n * current];
                            var b = table[current + n * i];
                            if (!included[a])
                            {
                                included[a] = true;
                                queue.Enqueue(a);
                            }
                            if (!included[b])
                            {
                                included[b] = true;
                                queue.Enqueue(b);
                            }
                        }
                    }
                }

                minSet = Math.Min(minSet, included.Count(b => b));
            }
        }

        return minSet;
	}

    int GetN(int length)
    {
        for (int i = 1; i * i <= length; i++)
        {
            if (i * i == length)
            {
                return i;
            }
        }
        return -1;
    }
}
