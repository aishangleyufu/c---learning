using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 超市商品系统
{
    class Cangku//干三件事情存储货物 进货 取货
    {
        //存储货物
        List<List<Productfather>> list = new List<List<Productfather>>();
        //添加货架 创建仓库的时候 list[0]存储Acer，list[1]存储Sumsung，list[2]存储酱油，list[3]存储酱油
        public Cangku()
        {
            list.Add(new List<Productfather>());
            list.Add(new List<Productfather>());
            list.Add(new List<Productfather>());
            list.Add(new List<Productfather>());
        }
        //进货
        public void Getpros(string strTyp, int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (strTyp)
                {
                    case "Acer": list[0].Add(new Acer(Guid.NewGuid().ToString(), 1000, "宏基笔记本")); break;
                    case "Sumsung": list[1].Add(new Sumsung(Guid.NewGuid().ToString(), 2000, "棒子笔记本")); break;
                    case "Jiangyou": list[2].Add(new Jiangyou(Guid.NewGuid().ToString(), 10, "老抽酱油")); break;
                    case "Banana": list[3].Add(new Banana(Guid.NewGuid().ToString(), 5, "大香蕉")); break;
                }
            }
        }

        //取货
        public Productfather[] Qupros(string strTyp, int count)
        {
            Productfather[] pros = new Productfather[count];
            for (int i = 0; i < count; i++)
            {
                switch (strTyp)
                {
                    case "Acer": pros[i]=list[0][0];
                        list[0].RemoveAt(0);
                        break;
                    case "Sumsung": pros[i]=list[1][0];
                        list[1].RemoveAt(0);
                        break;
                    case "Jiangyou": pros[i]=list[2][0];
                        list[2].RemoveAt(0);
                        break;
                    case "Banana": pros[i] = list[3][0];
                        list[3].RemoveAt(0);
                        break;
                }

                
            }
            return pros;

        }

        //附带功能 展示货物
        public void Showpros()
        {
            foreach (var item in list)
            {
                Console.WriteLine("我们仓库的:" + item[0].Name + "\t" + "有" + item.Count + "\t" + "每个" + item[0].Price + "元");
            }
        }

    }
}
