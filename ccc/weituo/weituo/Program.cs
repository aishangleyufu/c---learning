using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace weituo
{

    public delegate void DelSayhi(string name);
    class Program
    {
        static void Main(string[] args)
        {
            //Sayhi("张三", SayhiChinese);
            //DelSayhi del = (string name) => { Console.WriteLine("你好" + name); };
            //del("张三");

            Console.ReadKey();
        }
      
        //public static void Sayhi(string name,DelSayhi del)
        //{
        //    del(name);
        //}

        //public static void SayhiChinese(string name){
        //    Console.WriteLine("你好"+name);

        //}

        //   public static void SayhiEnglish(string name){
        //    Console.WriteLine("Hello"+name);

        //}
    }
}
