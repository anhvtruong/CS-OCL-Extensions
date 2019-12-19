using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OclExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "42,12";
            List<int> list = new List<int>() { 4, 4, 5, 61, 1};
            List<int> list2 = new List<int>() { 1, 4, 5, 1, 8 };
            HashSet<int> set = new HashSet<int>(list);
            HashSet<int> set2 = new HashSet<int>(list2);
            ConcurrentBag<int> bag = new ConcurrentBag<int>(list2);
            var e = set.Union(bag);
            Console.WriteLine(bag.Count(1));
            Console.WriteLine("Hello Extension Methods!");
            Console.WriteLine(list.IncludesAll(list2));
            Console.WriteLine(list.NotEmpty());
            var temp = list.SelectOcl(e => e > 4);
            Console.WriteLine(temp.Count);
            temp.Println();
        }
    }
}
