using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            const string myname = "karli";
            const string sexyname="angling";
            const string sillyname = "ploppy";
            Console.WriteLine("what is your name?");
            name = Console.ReadLine();
            switch (name.ToLower())
            {
                case (myname):
                    Console.WriteLine("you have the same name as me");
                    break;
                case (sexyname):
                    Console.WriteLine("what a sexy name you have");
                    break;
                case (sillyname):
                    Console.WriteLine("a very silly name");
                    break;
            }
            Console.WriteLine("HELLO {0}",name);
            Console.ReadKey();


        }
    }
}
