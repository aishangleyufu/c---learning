using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class CalNormal:CalFather
    {

        public override double GetRealMoney(double realMoney)
        {
            return realMoney;
        }
    }
}
