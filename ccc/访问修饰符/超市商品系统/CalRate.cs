using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class CalRate:CalFather
    {

        private double _rate;

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

         public override double GetRealMoney(double realMoney)
        {
            return realMoney * this.Rate;
        }

         public CalRate(double rate)
         {
             this.Rate = rate;
         }
    }
}
