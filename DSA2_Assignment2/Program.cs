using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA2_Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.fillMap();
            map.doMagic("Varna");
            Console.WriteLine("Done?");
               foreach(var item in map.cities)
               {
                   Console.WriteLine($"{item.name}:{item.distance}");
               }
            Console.WriteLine("\nAnd the fastest way is:\n");
            map.printFastestRoad("Varna", "Sofia");
        }
    }
}
