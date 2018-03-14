using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public abstract class JiSuan
    {
        private int num1;
        public int Num1
        {   
            get { return num1; }
            set { num1 = value; }
        }
        private int num2;
        public int Num2
        {
            get { return num2; }
            set { num2 = value; }
        }
        public JiSuan(int num1,int num2){
            this.Num1 = num1;
            this.Num2 = num2;
        }
        public abstract int GetResult(int n1, int n2);
    }
}
