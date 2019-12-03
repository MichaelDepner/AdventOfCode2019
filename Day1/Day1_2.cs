using System;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    public class Day1_2 : ISolver
    {
        public string Solve(string input)
        {
            string[] lines = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            return lines.Select( x => 
                getRemainingFuel( Convert.ToInt32(x), 0 )
            )
            .Sum()
            .ToString();
        }

        int getRemainingFuel(int initial, int accumulator) {
            int extra = (int) ( Math.Floor( (float)initial / 3 ) ) - 2;
            //System.Console.WriteLine(initial + "    " + extra);
            return extra <= 0 ? accumulator : getRemainingFuel(extra, accumulator+extra);
        }
    }
}