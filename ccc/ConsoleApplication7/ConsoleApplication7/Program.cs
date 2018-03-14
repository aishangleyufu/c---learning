using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "abcdefg";
            //char[] chs = s.ToCharArray();
            //chs[0] = 'b';
            //s= new string(chs);
            //Console.WriteLine(s);
            //Console.ReadKey();
            //StringBuilder sb = new StringBuilder();
            //string s = null;
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //for (int i = 0; i < 100000; i++)
            //{
            //    sb.Append(i);
            //}
            //sw.Stop();
            //Console.WriteLine(sb.ToString());
            //Console.WriteLine(sw.Elapsed);
            //Console.ReadKey();
            //string s = "as,+,2dadsada_0";
            //char[] chs = { ',','+', '_' };

            //string[] str = s.Split(chs, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(str[0]);
            //Console.ReadKey();

            //string str = Console.ReadLine();
            //if(str.Contains("老赵")){
            //    str=str.Replace("老赵","**");
            //}
            //Console.WriteLine(str);
            //Console.ReadKey();

            string str = "abcdefg";
            //for (int i = str.Length - 1; i >= 0; i--)
            //{
            //    Console.Write(str[i]);
            //}
            char[] chs = str.ToCharArray();
            for (int i = 0; i < chs.Length - 1; i++)
            {
               char temp = chs[i];
                chs[i] = chs[chs.Length - 1 - i];
                chs[chs.Length - 1 - i] = temp;

                  
            }
            str = new string(chs);
            Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
