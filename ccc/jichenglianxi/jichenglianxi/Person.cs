using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jichenglianxi
{
    public class Person
    {
        private string _name;
        private int _age;
        private char _gender;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public char Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public Person(string name,int age ,char gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }


    }
}
