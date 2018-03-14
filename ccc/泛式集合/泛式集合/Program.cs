using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 泛式集合
{
    class Program
    {
        static void Main(string[] args)
        {
           //Dictionary<int,string> dic=new Dictionary<int,string>();
           // dic.Add(1,"张三");
           // dic.Add(2,"lisi");
           // dic.Add(3,"王无");
           // dic[1]="新来的";
           // foreach(KeyValuePair<int,string> kv in dic){
           //     Console.WriteLine("{0}---------{1}",kv.Key,kv.Value);
            
           // }
            //int[] nums={1,2,3,4,5,6,7,8,9};
            //List<int> ji=new List<int>();

            //List<int> ou = new List<int>();
            //for(int i=0;i<nums.Length;i++){
            //    if(nums[i]%2==0){
            //        ou.Add(nums[i]);

            //    }
            //    else{
            //        ji.Add(nums[i]);
            //    }
            //}
            //ji.AddRange(ou);
            //foreach (int it in ji)
            //{
            //    Console.Write(it);
            //}
            string str = "Welcome to china";
            Dictionary<char,int> dic=new Dictionary<char,int>();
            for(int i=0;i<str.Length;i++){
                if (dic.ContainsKey(str[i]))
                {
                    dic[str[i]]++;
                }
                else{
                    dic[str[i]] = 1;

                }
            
            }
            foreach (KeyValuePair<char, int> kv in dic)
            {
                Console.WriteLine("字母{0}在文本中出现了{1}次", kv.Key, kv.Value);
            }

        }
    }
}
