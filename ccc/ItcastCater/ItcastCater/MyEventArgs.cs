using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater
{
    public class MyEventArgs:EventArgs
    {
        public int Temp { get; set; }

        public object Obj { get; set; }

        public decimal Money { get; set; }

        public string Name { get; set; }
    }
}
