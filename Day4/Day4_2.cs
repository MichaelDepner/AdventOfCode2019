using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day4
{
    public class Day4_2 : ISolver
    {
        public string Solve(string input)
        {
            var from = Convert.ToInt32(input.Split("-")[0]);
            var to = Convert.ToInt32(input.Split("-")[1]);

            //Range takes a starting position and how far to go, hence (to-from)
            var passwords = Enumerable.Range(from,to-from)
                // It is a six-digit number.
                .Where( x => x>99999 && x<1000000 )
                // Two adjacent digits are the same (like 22 in 122345).
                .Where( x => adjacencyCheck(x) )
                // Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
                .Where( x => digitsIncreaseCheck(x) );

            return passwords.Count().ToString();
        }

        public bool adjacencyCheck(int i) {
            var list = i.ToString().ToList();
            char previous = 'z';
            int streak = 1;

            //System.Console.WriteLine(i);

            foreach (char c in list) {
                //System.Console.WriteLine($"{previous},{c},{streak}");
                if (previous != c && streak == 2) {
                    return true;
                } else if (previous == c) {
                    streak++;
                } else {
                    streak = 1;
                    previous = c;
                }
            }

            //If we end on a streak of 2, return true as well
            if (streak == 2) {
                return true;
            } else {
                return false;
            }
            
        }

        public bool digitsIncreaseCheck(int i) {
            var list = i.ToString().ToList();
            int previous = 0;
            foreach (char c in list) {
                if (previous > Convert.ToInt32(c)) {
                    return false;
                }
                previous = Convert.ToInt32(c);
            }
            return true;
        }


    }
}