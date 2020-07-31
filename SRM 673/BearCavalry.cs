using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class BearCavalry
{
	public int countAssignments(int[] warriors, int[] horses)
	{
		var bravebeart = warriors[0];
		long result = 0;
        const int Mod = 1000000007;

        var otherWarriors = warriors.Skip(1).OrderByDescending(str => str).ToArray();
		Array.Sort(horses);

        for (int bravesHorse = 0; bravesHorse < horses.Length; bravesHorse++)
        {
            var bravesStrength = bravebeart * horses[bravesHorse];
            var otherHorses = GetOtherHorses(horses, bravesHorse);
            var index = -1;
            long count = 1;
            for (int w = 0; w < otherWarriors.Length; w++)
            {
                while (index + 1 < otherHorses.Count && otherWarriors[w] * otherHorses[index + 1] < bravesStrength)
                {
                    index++;
                }
                count *= Math.Max(0, index - w + 1);
                count %= Mod;
            }
            result += count;
            result %= Mod;
        }		

		return (int)result;
	}

	List<int> GetOtherHorses(int[] horses, int selected)
    {
		var result = new List<int>(horses.Length - 1);
        for (int i = 0; i < horses.Length; i++)
        {
            if (i != selected)
            {
                result.Add(horses[i]);
            }
        }
        return result;
    }
}
