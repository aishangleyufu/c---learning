using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Jianfa:JiSuan
    {

            public Jianfa(int Num1, int Num2)
                : base(Num1, Num2)
            {
            }
            public override int GetResult(int n1, int n2)
            {
                return n1 - n2;
            }

    }
}
