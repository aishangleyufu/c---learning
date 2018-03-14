using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石头剪刀布
{
    public enum Result
    {
        玩家赢,
        电脑赢,
        平手

    }
    class Caipan
    {

        public static Result Judge(int playernumber, int cpunumber)
        {
            if (playernumber - cpunumber == -1 || playernumber - cpunumber == 2)
            {
                return Result.玩家赢;
            }
            else if (playernumber-cpunumber==0)
	        {
		         return Result.平手;
	        }
            else
	        {
                 return Result.电脑赢;
	        }
        }
    }
}
