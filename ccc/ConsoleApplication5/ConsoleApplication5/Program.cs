using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            string text="" ;
            for (i = 0; i < 10; i++)
            {
                text = "Line " + Convert.ToString(i);
                Console.WriteLine("{0}", text);
            }
            Console.WriteLine("last loop text output={0}.", text);
            Console.ReadKey();
        }
    }
}
