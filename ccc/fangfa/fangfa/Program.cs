using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fangfa
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a1 = 10;
            //int a2 = 20;
            //int a=Program.GetMax(a1, a2);
            //Console.WriteLine(a);
            //Console.ReadKey();
            int ss=0;
            Console.WriteLine("请输入一个数字");
            string input=Console.ReadLine();
            ss=GetNumber(input);
            Console.WriteLine("输入的数字为{0}",ss);

        }

        public static int GetMax(int n1,int n2)
        {
            return n1>n2 ? n1:n2;


        }

        public static int GetNumber(string s)
        {
            while (true)
            {
                try
                {
                    int number = Convert.ToInt32(s);
                    return number;

                }
                catch
                {
                    Console.WriteLine("输入有误，清重新输入");
                    s = Console.ReadLine();
                }
            }
        }
    }
}
