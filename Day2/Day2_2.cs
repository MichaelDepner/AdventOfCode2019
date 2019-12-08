using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day2
{
    public class Day2_2 : ISolver
    {
        public string Solve(string input)
        {
            List<int> lines = input.Split(",").Select( x => Convert.ToInt32(x)).ToList();
            
            for (var a = 0; a<99; a++) {
                for (var b=0; b<99; b++) {
                    var linescopy = new int[lines.Count()];
                    Array.Copy(lines.ToArray(), linescopy, lines.Count());
                    linescopy[1] = a;
                    linescopy[2] = b;
                    var result = IntCode(linescopy.ToList(),0);
                    if ( result == 19690720 ){
                        return $"a: {a}, b: {b}, result:{100*a+b}";
                    }
                }
            }

            throw new System.NotImplementedException();
        }

        int IntCode(List<int> lines, int startpos) {
            //System.Console.WriteLine("");
            //Console.WriteLine(String.Join("; ", lines));

            var a = startpos+1;
            var b = startpos+2;
            var c = startpos+3;

            switch (lines[startpos])
            {
                case 1:
                    //System.Console.WriteLine(lines[lines[a]] + " + " + lines[lines[b]] + " = " + (lines[lines[a]] + lines[lines[b]]) );
                    //System.Console.WriteLine("Save to position "+lines[c]);
                    lines[lines[c]] = ( lines[lines[a]] + lines[lines[b]] );
                    return IntCode(lines, (startpos+4));
                case 2:
                    //System.Console.WriteLine(lines[lines[a]] + " * " + lines[lines[b]] + " = " + (lines[lines[a]] * lines[lines[b]]) );
                    //System.Console.WriteLine("Save to position "+lines[c]);
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