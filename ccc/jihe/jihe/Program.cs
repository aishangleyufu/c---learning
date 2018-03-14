using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jihe
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            //count 表示集合实际包含个数
            //capcity 可以包含的元素
            list.Add(1);
            list.Add(3.14);
            list.Add(true);
            list.Add("张三");
            list.Add('男');
            list.Add(5000m);
            list.Add(new int[] { 1, 2, 3, 4, 5, 6, 7, 7 });
            Person p = new Person();
            list.Add(p);
            list.AddRange(new string[] { "男", "女", "人妖", "四不像" });
            list.RemoveAt(3);
            list.Add(list);
            bool b = list.Contains(1);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Person)
                {
                    ((Person)list[i]).SayHello();
                }

                else if (list[i] is int[])
                {
                    for (int j = 0; j < ((int[])list[i]).Length; j++)
                    {
                        Console.WriteLine(((int[])list[i])[j]);
                    }
                }
                else
                {
                    Console.WriteLine(list[i]);
                }
            }
            Console.WriteLine(b);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            Console.ReadKey();

        }
    }

    public class Person
    {

        public void SayHello()
        {
            Console.WriteLine("hello motor");
        }
    }
}
