using System;
using System.Collections.Generic;

namespace lol
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> a = new HashSet<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(1);
            foreach (var VARIABLE in a)
            {
                Console.Write(VARIABLE+" ");
            }


        }
    }
}
