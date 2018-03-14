using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string usename;
            Console.WriteLine("Enter your name:");
            usename = Console.ReadLine();
            Console.WriteLine("Welcome {0}!", usename);

            double firstnumber, secondnumber;
            Console.WriteLine("Give me a number:");
            firstnumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Now,give me another number:");
            secondnumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("the sum of {0} and {1} is {2}.", firstnumber, secondnumber, firstnumber + secondnumber);
            Console.WriteLine("the result of subtracting {0} from {1} is {2}.", firstnumber, secondnumber, firstnumber - secondnumber);
            Console.WriteLine("the product of {0} and {1} is {2}.", firstnumber, secondnumber, firstnumber * secondnumber);
            Console.WriteLine("the result of dividing {0} from {1} is {2}.", firstnumber, secondnumber, firstnumber / secondnumber);
            Console.WriteLine("the reminder after dividing {0} by {1} is {2}.", firstnumber, secondnumber, firstnumber % secondnumber);
        }
    }
}
