using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @ref
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 20;
            Mix(ref n1, ref n2);
            Console.WriteLine("{0},{1}", n1, n2);

        }

        public static void Mix(ref int n1, ref int n2)
        {
            int temp = 0;
            temp = n1;
            n1 = n2;
            n2 = temp;

        }
    }
}
