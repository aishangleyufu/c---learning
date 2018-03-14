using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine(Guid.NewGuid().ToString());
            //Console.WriteLine(Guid.NewGuid().ToString());
            //Console.WriteLine(Guid.NewGuid().ToString());
            //Console.WriteLine(Guid.NewGuid().ToString());

            SuperMarket sm = new SuperMarket();
            sm.Showpro();
            sm.AskBuying();
            Console.ReadKey();
        }
    }
}
