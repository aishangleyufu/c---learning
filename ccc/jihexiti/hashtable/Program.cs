using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "张三");
            ht.Add(2, true);
            ht.Add(3, '男');
            ht.Add(false, "错误的");
            //在键值对集合中，根据键找值
            for(int i=0;i<ht.Count;i++){
                Console.WriteLine(ht[i]);

            }

            foreach (var item in ht.Keys)
            {
                Console.WriteLine(ht[item]);
            }
        }

    }
}
