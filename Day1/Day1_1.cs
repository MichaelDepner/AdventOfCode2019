using System;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    class Day1_1 : ISolver
    {

        public string Solve (string input) {
            string[] lines = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            return lines.Select( x => 
                //Divide number by 3, floor it, then minus 2
                Math.Floor( (float)int.Parse(x) / 3 ) - 2
            )
            .Sum()
            .ToString();
        }
    }
}
