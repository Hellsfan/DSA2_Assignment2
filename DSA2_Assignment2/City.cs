using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA2_Assignment2
{
    internal class City
    {
        public string name { get; set; }
        public City shortestRoad { get; set; }
        public int distance { get; set; }
        public City(string _name)
        {
            name = _name;
            distance = int.MaxValue;
        }
    }
}
