using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jichenglianxi
{
    public class Programmer:Person
    {
        public Programmer(string name, int age, char gender, int workyear):base(name,age,gender)
        {
            this.Workyear = workyear;
        }

        private int _workyear;
        public int Workyear
        {
            get { return _workyear; }
            set { _workyear = value; }
        }

        public void ProgrammerSayHello()
        {
            Console.WriteLine("我叫{0} 我的年龄是{1} 我是{2}生 我的工作年限是{3}年", this.Name, this.Age, this.Gender, this.Workyear);

        }
    }
}
