using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 文件流2
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用streamreader来读取一个文本文件
            //using (StreamReader sr = new StreamReader(@"C:\Users\c\Desktop\kk.txt",Encoding.Default))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        Console.WriteLine(sr.ReadLine());
            //    }
            //}

            using (StreamWriter sw = new StreamWriter(@"C:\Users\c\Desktop\kk.txt",true))
            {
                sw.Write("今天天气好晴朗");
            }

            Console.ReadKey();
        }
    }
}
