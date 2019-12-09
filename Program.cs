using System;
using System.Collections.Generic;
using System.Linq;

namespace OclExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "42,12";
            List<int> list = new List<int>() { 4, 4, 5, 61, 1, 4, 1, 1, 1 };
            List<int> list2 = new List<int>() { 1, 4, 5 };
            Console.WriteLine("Hello Extension Methods!");
            Console.WriteLine(list.IncludesAll(list2));
            Console.WriteLine(list.NotEmpty());
            Console.WriteLine(s.ToReal());
        }
    }
}
