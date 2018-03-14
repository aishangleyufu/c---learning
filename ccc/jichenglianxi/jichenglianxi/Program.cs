using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jichenglianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            //记者：我是记者  我的爱好是偷拍 我的年龄是34 我是一个男狗仔
            //司机：我叫舒马赫 我的年龄是43 我是男人  我的驾龄是 23年
            //程序员：我叫孙全 我的年龄是23 我是男生 我的工作年限是 3年

            Reporter rep = new Reporter("狗仔", 34, '男', "偷拍");
            rep.ReporterSayHello();
            Programmer pro=new Programmer("孙全",23,'男',3);
            pro.ProgrammerSayHello();
        }
    }

    
}
