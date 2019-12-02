using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Input day: ");
            var day = Console.ReadLine();
            System.Console.Write("Input part (1 or 2): ");
            var part = Console.ReadLine();
            ISolver executor = (ISolver)Activator.CreateInstance(Type.GetType("AdventOfCode2019.Day"+day+"_"+part));
            string input = System.IO.File.ReadAllText("Day"+day+"_"+part+".txt");
            System.Console.WriteLine(executor.Solve(input));
        }

        
      /*  
        //Something something dynamically load derived types from interface. Look at later.
        private static IEnumerable<ISolver> GetDerivedTypesFor(Type baseType)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetTypes()
                .Where(baseType.IsAssignableFrom)
                .Where(t => baseType != t);
        }
        */
    }

}
