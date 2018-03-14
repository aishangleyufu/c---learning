using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool flag = true;
            Console.WriteLine("请输入一个数字");
            try
            {
               number = Convert.ToInt32(Console.ReadLine());
               
            }
            catch
            {
                Console.WriteLine("输入的内容不能转换成数字");
                flag = false;
                
            }
            if (flag == true)
            {
                Console.WriteLine(number * 2);
            }
            Console.ReadKey();


        }
    }
}
