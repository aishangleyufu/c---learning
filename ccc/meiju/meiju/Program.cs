using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meiju
{

    public enum QQState{
        Online=1,
        Offline,
        Leave,
        Busy,
        Qme
}
        
    class Program
    {
        static void Main(string[] args)
        {
            #region int强制转换
            //QQState state = QQState.Online;
            //Console.WriteLine((int)QQState.Online);
            //Console.WriteLine((int)QQState.Offline);
            //Console.WriteLine((int)QQState.Leave);
            //Console.WriteLine((int)QQState.Busy);
            //Console.WriteLine((int)QQState.Qme);
            #endregion
            #region int转枚举类型
            //int n1 = 3;
            //QQState state1 = (QQState)n1;
            //Console.WriteLine(state1);
            //Console.ReadKey();
            #endregion
           // string s = "abxc";
           //QQState states= (QQState) Enum.Parse(typeof(QQState), s);
           //Console.WriteLine(states);
            QQState state = 0;
            Console.WriteLine("请输入你的qq在线状态 1--online 2--offline 3--leave 4--busy 5--Qme");
            string input = Console.ReadLine();
            switch (input)
                {
                    case "1": state = (QQState)Enum.Parse(typeof(QQState), input);
                        Console.WriteLine("您当前qq的状态是{0}.", state);
                        break;
                    case "2": state = (QQState)Enum.Parse(typeof(QQState), input);
                        Console.WriteLine("您当前qq的状态是{0}.", state);
                        break;
                    case "3": state = (QQState)Enum.Parse(typeof(QQState), input);
                        Console.WriteLine("您当前qq的状态是{0}.", state);
                        break;
                    case "4": state = (QQState)Enum.Parse(typeof(QQState), input);
                        Console.WriteLine("您当前qq的状态是{0}.", state);
                        break;

                    case "5": state = (QQState)Enum.Parse(typeof(QQState), input);
                        Console.WriteLine("您当前qq的状态是{0}.", state);
                        break;



                }

        }
    }
}
