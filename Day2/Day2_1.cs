using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day2
{
    public class Day2_1 : ISolver
    {
        public string Solve(string input)
        {
            List<int> lines = input.Split(",").Select( x => Convert.ToInt32(x)).ToList();
            
            //lines = new List<int>(){1,1,1,4,99,5,6,0,99}; //Uncomment to try other lists

            return IntCode(lines, 0).ToString();


            throw new System.NotImplementedException();
        }

        int IntCode(List<int> lines, int startpos) {
            System.Console.WriteLine("");
            Console.WriteLine(String.Join("; ", lines));

            var a = startpos+1;
            var b = startpos+2;
            var c = startpos+3;

            switch (lines[startpos])
            {
                case 1:
                    System.Console.WriteLine(lines[lines[a]] + " + " + lines[lines[b]] + " = " + (lines[lines[a]] + lines[lines[b]]) );
                    System.Console.WriteLine("Save to position "+lines[c]);
                    lines[lines[c]] = ( lines[lines[a]] + lines[lines[b]] );
                    return IntCode(lines, (startpos+4));
                case 2:
                    System.Console.WriteLine(lines[lines[a]] + " * " + lines[lines[b]] + " = " + (lines[lines[a]] * lines[lines[b]]) );
                    System.Console.WriteLine("Save to position "+lines[c]);
                    lines[lines[c]] = ( lines[lines[a]] * lines[lines[b]] );
                    return IntCode(lines, (startpos+4));
                case 99:
                    return lines[0];
                default:
                    throw new InvalidOperationException("Uh oh, invalid IntCode: "+lines[startpos]);
            }
        }

    }
}