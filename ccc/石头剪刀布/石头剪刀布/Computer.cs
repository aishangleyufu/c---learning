using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石头剪刀布
{
    class Computer
    {

        private string _fist;
        

        public string Fist
        {
    get { return _fist; }
    set { _fist = value; }
        }
        public int ShowFist()
        {
            Random r = new Random();
            int rNumber = r.Next(1, 4);
            switch(rNumber)
            {
                case 1:this.Fist="石头";break;
                case 2:this.Fist="剪刀";break;
                case 3:this.Fist="布";break;
            }
            return rNumber;
        }
    }
}
