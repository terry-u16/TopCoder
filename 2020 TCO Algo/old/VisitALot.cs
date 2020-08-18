using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class VisitALot
{
	bool[,] map;
	bool[,] seen;
	int[] dr = new int[] { -1, 1, 0, 0 };
	int[] dc = new int[] { 0, 0, 1, -1 };
	char[] directions = new char[] { 'N', 'S', 'E', 'W' };
	int height, width;

	public string travel(int R, int C, int[] obsr, int[] obsc)
	{
		height = R;
		width = C;
		map = new bool[height, width];
		seen = new bool[height, width];

        for (int i = 0; i < obsr.Length; i++)
        {
			map[obsr[i], obsc[i]] = true;
        }

		var movement = new List<char>();
		Dfs(0, 0, movement);
		
		return new string(movement.ToArray());
	}

	bool Dfs(int row, int column, List<char> movement)
    {
        if (movement.Count + 1 >= (height * width + 1) / 2)
        {
			return true;
        }
        else
        {
			seen[row, column] = true;

			for (int i = 0; i < dr.Length; i++)
			{
				var nextRow = row + dr[i];
				var nextColumn = column + dc[i];
				var nextDirection = directions[i];

				if (InMap(nextRow, nextColumn) && !map[nextRow, nextColumn] && !seen[nextRow, nextColumn])
				{
					movement.Add(nextDirection);

                    if (Dfs(nextRow, nextColumn, movement))
                    {
						return true;
                    }

					movement.RemoveAt(movement.Count - 1);
				}
			}

			seen[row, column] = false;

			return false;
		}
	}

	bool InMap(int row, int column)
    {
		return unchecked((uint)row < height && (uint)column < width);
    }
}