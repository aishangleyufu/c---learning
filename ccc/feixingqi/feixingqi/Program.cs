using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace feixingqi
{
    class Program
    {
        public static int[]  Maps=new int[110];
        //存储玩家a和b的坐标
        public static int[] PlayerPos = new int[2];
        public static string[] Playernames = new string[2];
        public static bool[] Flags = new bool[2];//初始值均为false
        static void Main(string[] args)
        {
            GameShow();
            #region 玩家姓名输入
            Console.WriteLine("请输入玩家A的姓名");
            Playernames[0] = Console.ReadLine();
            while (Playernames[0] == "")
            {
                Console.WriteLine("输入玩家姓名不能为空，请重新输入");
                Playernames[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家B的姓名");
            Playernames[1] = Console.ReadLine();
            while ((Playernames[1] == "")||(Playernames[0]==Playernames[1]))
            {
                if (Playernames[1] == "")
                {
                    Console.WriteLine("输入玩家姓名不能为空，请重新输入");
                    Playernames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("输入玩家B姓名不能与输入玩家A姓名相同，请重新输入");
                    Playernames[1] = Console.ReadLine();
                }
            }
            #endregion
            Console.Clear();
            GameShow();
            Console.WriteLine("{0}的士兵用A表示", Playernames[0]);
            Console.WriteLine("{0}的士兵用A表示", Playernames[1]);
            InitialMap();
            DrawMap();
            //当两个玩家都没到终点时 游戏继续
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                if (Flags[0] == false)
                {
                    PlayGame(0);
                }
                else
                {
                    Flags[0] = false;
                }
                if (PlayerPos[0] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻地赢了玩家{1}", Playernames[0], Playernames[1]);
                    break;
                }
                if (Flags[1] == false)
                {

                    PlayGame(1);
                }
                else
                {
                    Flags[1] = false;
                }
                if (PlayerPos[1] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻地赢了玩家{1}", Playernames[1], Playernames[0]);
                    break;
                }
            }
            Win();
            Console.ReadKey();

        }

        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**********************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****小渔夫的飞行棋****");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("**********************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InitialMap()
        { 
            int i=0;
        

            int[] luckyturn={6,23,40,55,69,83};
            for (i = 0; i < luckyturn.Length; i++)
            {
                Maps[luckyturn[i]] = 1;
            }
            int[] landmine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (i = 0; i < landmine.Length; i++)
            {
                Maps[landmine[i]] = 2;
            }
            int[] pause = { 9, 27, 60, 93 };
            for (i = 0; i < pause.Length; i++)
            {
                Maps[pause[i]] = 3;
            }
            int[] timetunnel = { 20, 25, 45, 63, 72, 88, 90 };
            for (i = 0; i < timetunnel.Length; i++)
            {
                Maps[timetunnel[i]] = 4;
            }


        }

        public static void DrawMap()
        {
            int i=0;
            int j=0;
            Console.WriteLine("图例:幸运轮盘:◎   地雷:☆   暂停:▲   时空隧道:卐");
            #region 第一横行
            for (i = 0; i < 30; i++)
            {

                Console.Write(DrawStringMap(i));
            }
            #endregion
            #region 第一竖行
            Console.WriteLine();

            for (i = 30; i <= 34; i++)
            {
                for (j = 0; j <= 28; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
            #endregion
            #region 第二横行
            for (i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            #region 第二竖行
            Console.WriteLine();
            for (i = 65; i <= 69; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion
            #region 第三横行
            for (i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            Console.WriteLine();
        }

        public static string DrawStringMap(int i)
        {
            string str = "";
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                str=("<>");
            }
            else if (PlayerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                str=("A");
            }
            else if (PlayerPos[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                str=("B");
            }
            else
            {
                switch (Maps[i])
                {
                    case 0: Console.ForegroundColor = ConsoleColor.Yellow;
                        str=("□");
                        break;
                    case 1: Console.ForegroundColor = ConsoleColor.Green;
                        str=("◎");
                        break;
                    case 2: Console.ForegroundColor = ConsoleColor.Blue;
                        str=("☆");
                        break;
                    case 3: Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        str=("▲");
                        break;
                    case 4: Console.ForegroundColor = ConsoleColor.Red;
                        str=("卐");
                        break;
                }
            }
            return str;
        }

        public static void PlayGame(int playernumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1, 7);

            Console.WriteLine("{0}按任意键开始掷筛子", Playernames[playernumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷筛子出了{1}", Playernames[playernumber],rNumber);
            Console.ReadKey(true);
            PlayerPos[playernumber] += rNumber;
            
            Console.WriteLine("{0}按任意键开始行动", Playernames[playernumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", Playernames[playernumber]);
            Console.ReadKey(true);

            if (PlayerPos[playernumber] == PlayerPos[1 - playernumber])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退6格", Playernames[playernumber], Playernames[1 - playernumber], Playernames[1 - playernumber]);
                PlayerPos[1 - playernumber] -= 6;
              
                Console.ReadKey(true);
            }
            else
            {
                switch (Maps[PlayerPos[playernumber]])
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块，安全", Playernames[playernumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘，1--交换位置 2--轰炸对方", Playernames[playernumber]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}和玩家{1}交换位置", Playernames[playernumber], Playernames[1 - playernumber]);
                                Console.ReadKey(true);
                                int temp = 0;
                                temp = PlayerPos[playernumber];
                                PlayerPos[playernumber] = PlayerPos[1 - playernumber];
                                PlayerPos[1 - playernumber] = temp;
                                Console.WriteLine("交换完成，按任意键继续游戏!!");
                                Console.ReadKey(true);
                                break;
                            }
                            if (input == "2")
                            {
                                Console.WriteLine("玩家{0}轰炸了玩家{1}，玩家{2}退六格", Playernames[playernumber], Playernames[1 - playernumber], Playernames[1 - playernumber]);
                                Console.ReadKey(true);
                                PlayerPos[1 - playernumber] -= 6;
                                Console.WriteLine("玩家{0}退了6格", Playernames[1 - playernumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("只能输入1或者2，1--交换位置 2--轰炸对方");
                                input = Console.ReadLine();
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷，退6格", Playernames[playernumber]);
                        Console.ReadKey(true);
                        PlayerPos[playernumber] -= 6;
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停，下回合暂停行动", Playernames[playernumber]);
                        Flags[playernumber] = true;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，进10格", Playernames[playernumber]);
                        Console.ReadKey(true);
                        PlayerPos[playernumber] += 10;
                        break;


                }//SWITCH
            }//ELSE
            ChangePos();
            Console.Clear();
            DrawMap();
        }

        public static void ChangePos()
        {
            if (PlayerPos[0] < 0)
            {
                PlayerPos[0] = 0;
            }
            if (PlayerPos[0] > 99)
            {
                PlayerPos[0] = 99;
            }
            if (PlayerPos[1] < 0)
            {
                PlayerPos[1] = 0;
            }
            if (PlayerPos[1] > 99)
            {
                PlayerPos[1] = 99;
            }
        }


        public static void Win()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                          ◆                      ");
            Console.WriteLine("                    ■                  ◆               ■        ■");
            Console.WriteLine("      ■■■■  ■  ■                ◆■         ■    ■        ■");
            Console.WriteLine("      ■    ■  ■  ■              ◆  ■         ■    ■        ■");
            Console.WriteLine("      ■    ■ ■■■■■■       ■■■■■■■   ■    ■        ■");
            Console.WriteLine("      ■■■■ ■   ■                ●■●       ■    ■        ■");
            Console.WriteLine("      ■    ■      ■               ● ■ ●      ■    ■        ■");
            Console.WriteLine("      ■    ■ ■■■■■■         ●  ■  ●     ■    ■        ■");
            Console.WriteLine("      ■■■■      ■             ●   ■   ■    ■    ■        ■");
            Console.WriteLine("      ■    ■      ■            ■    ■         ■    ■        ■");
            Console.WriteLine("      ■    ■      ■                  ■               ■        ■ ");
            Console.WriteLine("     ■     ■      ■                  ■           ●  ■          ");
            Console.WriteLine("    ■    ■■ ■■■■■■             ■              ●         ●");
            Console.ResetColor();
        }

    }
}
