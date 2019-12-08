using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class Day3_1 : ISolver
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

            var dict = new Dictionary<(int,int), List<int>>();
            dict = addLine(dict, list1, 1);
            dict = addLine(dict, list2, 2);

            var crossings = dict.Where( coord => coord.Value.Count() > 1 );
            /*foreach (var thing in crossings) {
                System.Console.Write(thing.Key);
                foreach(int i in thing.Value) {
                    System.Console.Write(i+", ");
                }
                System.Console.WriteLine();
            }*/

            //Get the closest manhattan crossing
            var manhattan = crossings.Select( coord => Math.Abs(coord.Key.Item1) + Math.Abs(coord.Key.Item2)).OrderBy( x => x );
            return manhattan.ToList()[0].ToString();
        }

        public Dictionary<(int,int), List<int>> addLine(Dictionary<(int,int), List<int>> dict, List<string> list, int listNumber) {
            var x = 0;
            var y = 0;
            foreach (var command in list) {
                string direction = command[0].ToString();
                var length = command.Substring(1);
                for(var count = Convert.ToInt32(length); count>0; count--) {
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
                    if (dict.ContainsKey((x,y)) && !dict[(x,y)].Contains(listNumber)) {
                        dict[(x,y)].Add(listNumber);
                    } else if (dict.ContainsKey((x,y)) && dict[(x,y)].Contains(listNumber)) {
                        // Do nothing
                    } else {
                        dict.Add((x,y),new List<int>(){listNumber});
                    }
                    
                }
            }
            return dict;
        }

    }
}