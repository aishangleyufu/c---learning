using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chengfakoujue
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 0;
            //int j = 0;
            //bool flag = true;
            //for (i = 2; i <= 100; i++)
            //{
            //    for (j = 2; j < (i); j++)
            //    {
            //        //除尽了说明不是质数break
            //        if (i % j == 0)
            //        {

            //            flag = false;
            //            break;
            //        }


            //    }

            //    if (flag)
            //    {
            //        Console.WriteLine("素数{0}", i);

            //    }
            //    flag = true;
            //}
            //Console.ReadKey();
            Random r = new Random();
            while(true){
                
                int rnumber=r.Next(1,6);
                Console.WriteLine("{0}",rnumber);
                Console.ReadKey();


            }


        }
    }
}
