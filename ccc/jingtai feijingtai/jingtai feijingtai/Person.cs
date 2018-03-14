using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jingtai_feijingtai
{
    class Person
    {
        public void M1()
        {
            Console.WriteLine("我是非静态的方法");
        }

        public static void M2()
        {
             Console.WriteLine("我是静态的方法");
        }
    }
}
