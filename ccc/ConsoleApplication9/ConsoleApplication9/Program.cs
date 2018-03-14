using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数");
            int num1 = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                try
                {
                    if (num1 > -10000 & num1 < 10000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("输入的数据超过范围，请重新输入");
                        num1 = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.WriteLine("输入的数据有误，请重新输入");
                    num1 = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("请输入第二个数");
            int num2=Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                try
                {
                    if (num2 > -10000 & num2 < 10000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("输入的数据超过范围，请重新输入");
                        num2 = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.WriteLine("输入的数据有误，请重新输入");
                    num2 = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("请输入符号 + - * /");
            string opt = Console.ReadLine();
            while(true)
            {
            try
            {
                if (opt == "+" || opt == "-" || opt == "*" || opt == "/")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("输入的符号有误，请重新输入");
                    opt = Console.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("输入的符号有误，请重新输入");
                opt = Console.ReadLine();
            }
            }

            JiSuan js = GetOptResult(opt, num1, num2);
            int result = js.GetResult(num1, num2);
            Console.WriteLine("计算的结果是{0}", result);
            Console.ReadKey();


        }

        public static JiSuan GetOptResult(string opt, int num1, int num2)
        {
            JiSuan js = null;
            switch (opt)
            {
                case "+": js =new Add(num1, num2);
                    break;
                case "-": js = new Jianfa(num1, num2);
                    break;
            }
            return js;
        }
    }
}
