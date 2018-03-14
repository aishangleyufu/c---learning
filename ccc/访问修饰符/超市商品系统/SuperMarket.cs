using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
     class SuperMarket
    {
        //创建仓库对象
         int j = 0;
        Cangku ck = new Cangku();
        public SuperMarket()
        {
            ck.Getpros("Acer", 1000);
            ck.Getpros("Sumsung", 1000);
            ck.Getpros("Jiangyou", 1000);
            ck.Getpros("Banana", 1000);

        }

        //与用户交互过程
        public void AskBuying()
        {
            int count = 0;
             bool flag1 = true;
            Productfather[] total_pros = new Productfather[10000];
            Console.WriteLine("欢迎光临，请问您需要些神马");
            Console.ReadKey(true);
            while (flag1 == true)
            {

                Console.WriteLine("我们有Acer，Sumsung，Jiangyou，Banana.");
                string strType = Console.ReadLine();
                while(true){
                if (strType!="Acer"&&strType!="Sumsung"&&strType!="Jiangyou"&&strType!="Banana")
                {
                    Console.WriteLine("输入有误 我们商店只有商品Acer，Sumsung，Jiangyou，Banana.");
                    strType = Console.ReadLine();
                }
                else
	            {
                        break;
	            }
                }

                    Console.WriteLine("您需要多少");
                    count = Convert.ToInt32(Console.ReadLine());
                   while (true)
                {
                    if (count>0&&count<1000)
                    {
                        break;
                    }
                    else if (count>=1000)
                    {
                        Console.WriteLine("您输入的数量大于仓库中货物数量，请重新输入");
                        count = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("您输入的数量不正确，请重新输入");
                        count = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Productfather[] pros = ck.Qupros(strType, count);
                for (int i = 0; i < count; i++)
                {
                    total_pros[j] = pros[i];
                    j++;
                }

                Console.WriteLine("本项购买结束如果需要继续购买输入1，退出输入2");
                string inputp=Console.ReadLine();
                while (true)
                {
                    if (inputp == "1")
                    {
                        break;
                    }
                    else if (inputp == "2")
                    {
                        flag1 = false;
                        break;
                        
                    }
                    else
                    {
                        Console.WriteLine("输入语法错误 请重新输入1或者2 1--继续购买 2--退出");
                        inputp = Console.ReadLine();
                    }
                }
            }
            Productfather[] pros_total = new Productfather[j];
            for (int i = 0; i < j; i++)
            {
                pros_total[i] = total_pros[i];
            }
            double realMoney = GetMoney(pros_total);
            Console.WriteLine("今天您应付{0}元", realMoney);
            Console.ReadKey();
            Console.WriteLine("请选择优惠类型,1---不打折 2---打9折 3---打85折 4--买300送50 5--买500送100");
            string input = Console.ReadLine();
            //通过简单工厂的工作模式返回 传入打折类型
            CalFather cal = GetCal(input);
            double totalmoney = cal.GetRealMoney(realMoney);
            Console.WriteLine("打完折后 您应付{0}元", totalmoney);
            Console.ReadKey(true);
            Console.WriteLine("以下是你的购物信息");
            foreach (var item in pros_total)
            {
                Console.WriteLine("货物名称：" + item.Name + "\t" + "货物单价:" + item.Price + "\t" + "货物编号:" + item.Id);
            }
        }
    
        public CalFather GetCal(string input)
        {
            CalFather cal = null;
            switch (input)
            {
                case "1": cal = new CalNormal(); break;
                case "2": cal = new CalRate(0.9); break;
                case "3": cal = new CalRate(0.85); break;
                case"4" :cal=new CalMN(300,50);break;
                case"5": cal=new CalMN(500,100);break;

            }
            return cal;
        }

        public double GetMoney(Productfather[] pros)
        {
            double realMoney = 0;
            for (int i = 0; i < pros.Length; i++)
            {
                realMoney += pros[i].Price;
            }

            return realMoney;
        }
        
        public void Showpro()
        {
            ck.Showpros();
        }
    }
}
        