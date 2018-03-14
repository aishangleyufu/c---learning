using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 接口练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //真的鸭子会游泳，木头鸭子不会游泳，橡皮鸭子会游泳
            Isswimming swim = new Realduck();
            swim.swim();
            Console.ReadKey();
        }
    }

    public class Realduck:Isswimming
    {
        public void swim()
        {
            Console.WriteLine("真鸭子靠翅膀游泳");
        }
    }

    public class Muduck
    {
    }

    public class Xpduck:Isswimming
    {
        public void swim()
        {
            Console.WriteLine("橡皮鸭子飘着游泳");
        }
    }

    public interface Isswimming
    {
         void swim();
    }
}
