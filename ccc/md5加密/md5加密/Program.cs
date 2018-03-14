using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace md5加密
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入密码");
            string result = getStringMd5(Console.ReadLine());
            Console.WriteLine(result);
        }

        private static string getStringMd5(string p)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(p);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bts=md5.ComputeHash(buffer);
            string str = "";
            for (int i = 0; i <bts.Length; i++)
            {
                str += bts[i].ToString("x2");
            }
            return str;

        }
    }
}
