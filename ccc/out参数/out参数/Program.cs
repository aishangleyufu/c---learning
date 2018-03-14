using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace out参数
{
    class Program
    {
        static void Main(string[] args)
        {
           // int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 8 };
            //int[] res=GetMaxMinSumAvr(numbers);
            //Console.WriteLine("最大值时{0}，最小值是{1}，总和是{2}，平均值是{3}.",res[0],res[1],res[2],res[3]);
            //int max = 0;
            //int min = 0;
            //int sum = 0;
            //int avr = 0;
            //Test(numbers, out max, out min, out sum, out avr);
            //Console.WriteLine("最大值时{0}，最小值是{1}，总和是{2}，平均值是{3}.", max, min, sum, avr);
            int num = 0;
            bool b = true;
            string sinput = "";

            while (true)
            {
            
                sinput=Console.ReadLine();
                b = MyTryParse(sinput, out num);
                Console.WriteLine(b);
                Console.WriteLine(num);

              //  Console.ReadKey();
            }

        }

        public static int[] GetMaxMinSumAvr(int[] nums)
        {
            int[] result = new int[4];
            result[0]=nums[0];
            result[1] = nums[1];
            result[2] = 0;
            result[3] = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > result[0])
                {
                    result[0] = nums[i];
                }
                if (nums[i] < result[1])
                {
                    result[1] = nums[i];
                }
                result[2] += nums[i];
            }
            result[3] = result[2] / nums.Length;
            return result;
        }

        public static void Test(int[] nums, out int max, out int min, out int sum, out int avr)
        {
            max = nums[0];
            min = nums[0]; ;
            sum = 0;
            avr = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                }
                if (nums[i] < min)
                {
                    min = nums[i];
                }
                sum += nums[i];
            }
            avr = sum / nums.Length;


        }

        public static bool MyTryParse(string s, out int result)
        {
            result = 0;
            try
            {
                result = Convert.ToInt32(s);
                return true;
            }
            catch
            {
                
                return false;
            }

        }
    }
}
