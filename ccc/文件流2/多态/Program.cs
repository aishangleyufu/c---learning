using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 多态
{
    class Program
    {
        static void Main(string[] args)
        {
            //让一个对象表现出多种状态
            //虚方法 抽象类 借口
          //  Person[] pers = new Person[6];
            CHinese cn1 = new CHinese("渔夫");
            CHinese cn2 = new CHinese("醒醒");
            Japanese j1 = new Japanese("树下君");
            Japanese j2 = new Japanese("靖边太郎");
            Koera k1 = new Koera("金三胖");
            Koera k2 = new Koera("金二胖");
            Person[] pers = { cn1, cn2, j1, j2, k1, k2 };
            for (int i = 0; i < pers.Length; i++)
            {
                //if (pers[i] is CHinese)
                //{
                //    ((CHinese)pers[i]).Sayhello();
                //}
                //else if (pers[i] is Japanese)
                //{
                //    ((Japanese)pers[i]).Sayhello();

                //}
                //else
                //{
                //    ((Koera)pers[i]).Sayhello();
                //}
                pers[i].Sayhello();
            }
        }
    }

    public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        public Person(string name)
        {
            this.Name = name;
        }

        public virtual void Sayhello()
        {
            Console.WriteLine("我是好人");
        }
    }

    public class CHinese : Person
    {

        public CHinese(string name)
            : base(name)
        {
        }

        public override void Sayhello()
        {
            Console.WriteLine("我是中国人，我叫{0}",this.Name);
        }
    }

    public class Japanese : Person
    {
        public Japanese(string name) : base(name)
        { 
        }

        public override void Sayhello()
        {
            Console.WriteLine("我是日本人,我叫{0}",this.Name);
        }

    }

    public class Koera : Person
    {
        public Koera(string name)
            : base(name)
        {

        }

        public override void Sayhello()
        {
            Console.WriteLine("我是韩国人,我叫{0}",this.Name);

        }
    }


}
