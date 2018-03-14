using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shuzu
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            int[] nums={0,1,8,3,10,5,6,7};
            int max = int.MinValue;
            int min = int.MaxValue;
            //Array.Reverse(nums);
            Array.Sort(nums);
           
            for (i = 0; i <= 7; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
