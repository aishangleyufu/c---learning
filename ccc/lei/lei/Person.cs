using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lei
{
    class Person
    {
         string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

          
                _name = value;
            }

        }
      int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    value = 0;
                }
                _age = value;

            }

        }

        char _gender;

        public char Gender
        {
            get
            {
                if(_gender!='男'&&_gender!='女'){
                    return _gender='男';
                }
                return _gender;
            }
            set
            {
               _gender = value;
            }

        }

        public void CHLSS()
        {
            Console.WriteLine("我叫{0}，今年{1}岁了，是个{2}的，会吃喝拉撒睡呦……", this.Name, this.Age, this.Gender);
        }

    }
}
