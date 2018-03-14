using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace runnianjudge
{
    class Program
    {
     
        static void Main(string[] args)
        {

            int year = 0;
            int month = 0;
            int day = 0;
            bool flag = true;
            Console.WriteLine("请输入年份");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入月份");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month >= 1 && month <= 12)
                    {
                        switch (month)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                                day = 31;
                                break;
                            case 2:
                                if ((year % 400 == 0) || (year % 4 == 0) && (year % 100 != 0))
                                {
                                    day = 29;
                                }
                                else
                                {
                                    day = 28;
                                }
                                break;
                            default: day = 30;
                                break;



                        }

                    }
                    else
                    {
                        Console.WriteLine("输入的月份不在范围内,程序退出");
                        flag = false;

                    }
                }
                catch
                {
                    Console.WriteLine("输入的月份有误,程序退出");
                    flag = false;
                }

            }
            catch
            {
                Console.WriteLine("输入的年份有误,程序退出");
                flag = false;
            }
            if (flag)
            {

                Console.WriteLine("{0}年{1}月有{2}天", year, month, day);
            }

        }
    }
}
