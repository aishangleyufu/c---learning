using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 文件类
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllLines(@"C:\Users\c\Desktop\kk.txt", new string[] { "awe", "ee1e12", "dasdas" });
            File.AppendAllLines(@"C:\Users\c\Desktop\kk.txt", new string[] { "awe", "ee1e12", "dasdas" });
        }
    }
}
