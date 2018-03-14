using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class Acer:Productfather
    {
        public Acer(string id, double price, string name)
            : base(id, price, name)
        {
        }
    }
}
