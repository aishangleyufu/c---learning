using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 值传递和引用传递
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Person
    {
        public void CHLSS()
        {
            Console.WriteLine("我是人类，我会吃喝拉撒睡");
        }
    }

    public class Nbaplayer
    {
        public void Koulan()
        {
            Console.WriteLine("我是球员 我会扣篮");
        }
    }

    public class Student : Person,Ikoulan
    {
        public void Koulan()
        {
            Console.WriteLine("我是学生 我也会扣篮");
        }

    }

    public interface Ikoulan
    {
        void Koulan();
    }
}
