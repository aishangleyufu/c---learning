using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fangfazonghe
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum1 = 0;
            Console.WriteLine("请输入第一个数字");
            string strNumberone = Console.ReadLine();
            int numberOne = GetNum(strNumberone);
            Console.WriteLine("请输入第二个数字");
            string strNumbertwo= Console.ReadLine();
            int numberTwo = GetNum(strNumbertwo);
            JudgeNumber(ref numberOne, ref numberTwo);
            sum1 = GetSum(numberOne, numberTwo);
            Console.WriteLine(sum1);
             
        }

        public static int GetNum(string s)
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
                    Console.WriteLine("输入有误，请重新输入");
                    s = Console.ReadLine();


                }
            }

        }

        public static void JudgeNumber(ref int n1,ref int n2)
        {
            while (true)
            {
                if (n1 < n2)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("第一个数字不能大于等于第二个数字,请重新输入第一个数字");
                    string s1 = Console.ReadLine();
                    n1 = GetNum(s1);
                    Console.WriteLine("请输入第二个数字");
                    string s2 = Console.ReadLine();
                    n2 = GetNum(s2);

                }
            }
        }

        public static int GetSum(int n1, int n2)
        {
            int sum=0;
            int i=0;
            for (i = n1; i <= n2; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
