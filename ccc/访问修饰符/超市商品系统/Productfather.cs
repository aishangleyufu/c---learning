using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class Productfather
    {
        private double _price;


        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private double _count;

        public double Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private string _name;
        

         public string Name
            {
                get { return _name; }
                 set { _name = value; }
            }
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Productfather(string id,double price,string name)
        {
            this.Price = price;
            this.Name = name;
            this.Id = id;

        }
    }
}
