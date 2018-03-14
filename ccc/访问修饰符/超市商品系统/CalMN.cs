using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class CalMN:CalFather
    {
        //买m送n 买500送100
        private double _m;

        public double M
        {
            get { return _m; }
            set { _m = value; }
        }

        private double _n;

        public double N
        {
            get { return _n; }
            set { _n = value; }
        }

        public override double GetRealMoney(double realMoney)
        {
            if (realMoney>=this.M)
            {
                return realMoney - (int)(realMoney / this.M) * this.N;
            }
            else
            {
                return realMoney;
            }
        }

        public CalMN(double m, double n)
        {
            this.M = m;
            this.N = n;
        }
    }
}
