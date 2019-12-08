using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class Day3_2 : ISolver
    {
        public string Solve(string input)
        {
            var list1 =  input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            )[0].Split(",").Select( s => Convert.ToString(s)).ToList();

            var list2 =  input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            )[1].Split(",").Select( s => Convert.ToString(s)).ToList();

            var dict = new Dictionary<(int,int), List<(int,int)>>();
            dict = addLine(dict, list1, 1);
            dict = addLine(dict, list2, 2);

            var crossings = dict.Where( coord => coord.Value.Count() > 1 );
            /* foreach (var thing in crossings) {
                System.Console.WriteLine(thing.Key);
                foreach(var touple in thing.Value) {
                    System.Console.WriteLine(touple.Item1+", "+touple.Item2);
                }
                System.Console.WriteLine();
                System.Console.WriteLine();
            } */

            var shortestCircuit = crossings.Select( coord => coord.Value[0].Item2 + coord.Value[1].Item2 ).Min();
            return shortestCircuit.ToString();
        }

        public Dictionary<(int,int), List<(int,int)>> addLine(Dictionary<(int,int), List<(int,int)>> dict, List<string> list, int listNumber) {
            var x = 0;
            var y = 0;
            var pathLength = 0;
            foreach (var command in list) {
                string direction = command[0].ToString();
                var length = Convert.ToInt32( command.Substring(1) );
                for(var count = length; count>0; count--) {
                    switch (direction)
                    {
                        case "U":
                            y++;
                            break;
                        case "D":
                            y--;
                            break;
                        case "L":
                            x--;
                            break;
                        case "R":
                            x++;
                            break;
                        default:
                            throw new System.NotImplementedException("Unknown direction: "+direction);
                    }
                    pathLength++;
                    if (dict.ContainsKey((x,y)) && !dict[(x,y)].Any( touple => touple.Item1 == listNumber )) {
                        dict[(x,y)].Add((listNumber,pathLength));
                    } else if (dict.ContainsKey((x,y)) && dict[(x,y)].Any( touple => touple.Item1 == listNumber )) {
                        // Do nothing
                    } else {
                        dict.Add((x,y),new List<(int,int)>(){(listNumber,pathLength)});
                    }
                    
                }
            }
            return dict;
        }

    }
}