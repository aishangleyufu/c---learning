using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jihexiti
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.AddRange(new int[] { 1, 2, 3, 4, 6, 5, 4, 3, 2, 2 });
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += (int)list[i];
            }
            Console.WriteLine(sum);
            //object是int类型的父类

            ArrayList list2 = new ArrayList();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int rNumber = r.Next(0, 10);
                if (!list2.Contains(rNumber))
                {
                    list2.Add(rNumber);
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list2[i]);

            }
        }
    }
}
