using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class HorseRacing
{
	public int validateTicket(string[] races, string ticket)
	{
        if (ContainsRepetation(ticket))
        {
            return -1;
        }

        foreach (var horse in ticket)
        {
            if (races.All(race => !race.Contains(horse)))
            {
                return -1;
            }
        }

        var result = 0;

        foreach (var race in races)
        {
            var count = 0;
            foreach (var c in ticket)
            {
                if (race.Contains(c))
                {
                    count++;
                }
            }

            if (count > 1)
            {
                return -1;
            }
            else
            {
                if (ticket.Contains(race[0]))
                {
                    result++;
                }
            }
        }

		return result;
	}

	bool ContainsRepetation(string s)
    {
		var counts = new int[256];
        foreach (var c in s)
        {
			counts[c]++;
        }

        foreach (var count in counts)
        {
            if (count > 1)
            {
                return true;
            }
        }

        return false;
    }
}
