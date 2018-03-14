using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lei
{
    class Program
    {
        static void Main(string[] args)
        {
            Person yuFu = new Person();
            yuFu.Name = "渔夫";
            yuFu.Age = 22;
            yuFu.Gender ='男';
            yuFu.CHLSS();
            Console.ReadKey();
        }
    }
}
