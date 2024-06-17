using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_游戏头
{
    class Program
    {
        //我们用静态字段来模拟全局变量
        public static int[] Maps = new int[100];
        //声明一个静态数组用来存储玩家A和玩家B的坐标
        static int[] PlayerPos = new int[2];
        //存储两个玩家的姓名
        static string[] PlayerNames = new string[2];
        //两个玩家的标记
        static bool[] Flags = new bool[2];//Flags[0]默认是false Flags[1]默认也是false 
        static void Main(string[] args)
        {
            GameShow();//游戏头
            #region 输入玩家姓名
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("请输入玩家A的姓名");
            PlayerNames[0] = Console.ReadLine();
            while (PlayerNames[0] == "")
            {
                Console.WriteLine("玩家A姓名不能为空，请重新输入");
                PlayerNames[0] = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("请输入玩家B的姓名");
            PlayerNames[1] = Console.ReadLine();
            while (PlayerNames[1] == "" || PlayerNames[1] == PlayerNames[0])
            {
                if (PlayerNames[1] == "")
                {
                    Console.WriteLine("玩家B姓名不能为空，请重新输入");
                    PlayerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家A的姓名不能跟玩家B的姓名相同，请重新输入");
                    PlayerNames[1] = Console.ReadLine();
                }
            }
            #endregion
            Console.WriteLine("{0}的士兵用A表示", PlayerNames[0]);
            Console.WriteLine("{0}的士兵用B表示", PlayerNames[1]);
            InitailMap();//初始化
            DrawMap();//地图

            //当玩家A跟玩家B没有一个人在终点的时候 两个玩家不停的去玩游戏
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                if (Flags[0] == false)
                {
                    PlayGame(0);//Flags[0]=true;
                }
                else
                {
                    Flags[0] = false;
                }
                if (PlayerPos[0] >= 99)
                {
                    Console.WriteLine("玩家{0}赢了玩家{1}",PlayerNames[0],PlayerNames[1]);
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
                if (PlayerPos[1]>=99)
                {
                    Console.WriteLine("玩家{0}赢了玩家{1}", PlayerNames[1], PlayerNames[0]);
                    break;
                }
            }//while
            Win();
            Console.ReadKey();
        }


        //1.画游戏头
        /// <summary>
        /// 游戏头
        /// </summary>
        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("****************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("****************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("****************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*********飞飞飞行棋*********");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("****************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("****************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("****************************");
        }

        //2.初始化地图（加载地图所需要的资源）
        //将整数数组中的数字编程控制台中显示的特殊字符串的这个过程 就是初始化地图
        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitailMap()
        {
            int[] luckyTurn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘是●
            for (int i = 0; i < luckyTurn.Length; i++)
            {
                //int index = luckyTurn[i];
                Maps[luckyTurn[i]] = 1;
            }
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷是☆
            for (int i = 0; i < landMine.Length; i++)
            {
                Maps[landMine[i]] = 2;
            }
            int[] pause = { 9, 27, 60, 93 };//暂停是▲
            for (int i = 0; i < pause.Length; i++)
            {
                Maps[pause[i]] = 3;
            }
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道是※
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                Maps[timeTunnel[1]] = 4;
            }
        }

        /// <summary>
        /// 画地图
        /// </summary>
        public static void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("幸运轮盘是●，地雷是☆，暂停是▲，时空隧道是※");
            #region 第一横行
            //第一横行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }//for 
            #endregion
            //画完第一横行后 应该换行
            Console.WriteLine();
            #region 第一竖行
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j <= 28; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
            #endregion
            #region 第二横行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            //画完第二横行应该换行
            Console.WriteLine();
            #region 第二竖行
            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion
            #region 第三横行
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            //画完最后一行应该换行
            Console.WriteLine();
        }//DrawMap结尾

        /// <summary>
        /// 从画地图的方法中抽象出来的一个方法
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string DrawStringMap(int i)
        {
            string str = "";
            #region 画图
            //如果玩家A跟玩家B的坐标相同，并且都在这个地图上，画一个尖括号
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                str = "<>";
            }
            else if (PlayerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //shift+空格
                str = "A";
            }
            else if (PlayerPos[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                str = "B";
            }
            else
            {
                switch (Maps[i])
                {

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        str = "●";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        str = "☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "※";
                        break;
                }//switch
            }//else 
            return str;
            #endregion
        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="playNumber"></param>
        public static void PlayGame(int playNumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1, 7);
            Console.WriteLine("{0}按任意键开始掷骰子", PlayerNames[playNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷出了{1}", PlayerNames[playNumber], rNumber);
            PlayerPos[playNumber] += rNumber;
            ChangePos();
            Console.ReadKey(true);
            Console.WriteLine("{0}按任意键开始行动", PlayerNames[playNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", PlayerNames[playNumber]);
            Console.ReadKey(true);
            //玩家A有可能踩到了玩家B 方块 幸运转盘 地震 暂停 时空隧道 
            if (PlayerPos[playNumber] == PlayerPos[1 - playNumber])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退六格", PlayerNames[playNumber], PlayerNames[1 - playNumber], PlayerNames[1 - playNumber]);
                PlayerPos[1 - playNumber] -= 6;
                //ChangePos();
                Console.ReadKey(true);
            }
            else//踩到了关卡
            {
                //玩家的坐标
                switch (Maps[PlayerPos[playNumber]])  //0 1 2 3 4
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块，安全", PlayerNames[playNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘，请选择1--交换位置 2--轰炸对方使对方退六格", PlayerNames[playNumber]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择跟玩家{1}交换位置", PlayerNames[playNumber], PlayerNames[1 - playNumber]);
                                Console.ReadKey(true);
                                int temp = PlayerPos[playNumber];
                                PlayerPos[playNumber] = PlayerPos[1 - playNumber];
                                PlayerPos[1 - playNumber] = temp;
                                Console.WriteLine("交换完成！！！按任意键继续游戏！！！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{2}退六格", PlayerNames[playNumber], PlayerNames[1 - playNumber], PlayerNames[1 - playNumber]);
                                Console.ReadKey(true);
                                PlayerPos[1 - playNumber] -= 6;
                                //ChangePos();
                                Console.WriteLine("玩家{0}退了6格", PlayerNames[1 - playNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("只能输入1或者2，1--交换位置，2--轰炸对方");
                                input = Console.ReadLine();
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷，退六格", PlayerNames[playNumber]);
                        Console.ReadKey(true);
                        PlayerPos[playNumber] -= 6;
                        //ChangePos();
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停，暂停一回合", PlayerNames[playNumber]);
                        Flags[playNumber] = true;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，前进十格", PlayerNames[playNumber]);
                        PlayerPos[playNumber] += 10;
                        //ChangePos();
                        Console.ReadKey(true);
                        break;
                }//switch
            }//else
            ChangePos();//perfact
            Console.Clear();
            DrawMap();
        }

        /// <summary>
        /// 当玩家坐标发生改变的时候调用
        /// </summary>
        public static void ChangePos()
        {
            if (PlayerPos[0] < 0)
            {
                PlayerPos[0] = 0;
            }
            if (PlayerPos[0] >= 99)
            {
                PlayerPos[0] = 99;
            }
            if (PlayerPos[1] < 0)
            {
                PlayerPos[1] = 0;
            }
            if (PlayerPos[1] >= 99)
            {
                PlayerPos[1] = 99;
            }
        }

        /// <summary>
        /// 胜利
        /// </summary>
        public static void Win()
        {
            Console.WriteLine("              ■                 ■■■  ");
            Console.WriteLine("■■■■  ■  ■            ■■  ■               ■  ");
            Console.WriteLine("■    ■  ■  ■                  ■           ■  ■");
            Console.WriteLine("■    ■ ■■■■■■       ■■■■■■■     ■  ■");
            Console.WriteLine("■■■■ ■   ■               ■ ■ ■        ■  ■ ");
            Console.WriteLine("■    ■      ■             ■   ■  ■       ■  ■");
            Console.WriteLine("■    ■ ■■■■■■      ■     ■   ■      ■  ■");
            Console.WriteLine("■■■■      ■          ■      ■     ■    ■  ■");
            Console.WriteLine("■    ■      ■                  ■               ■");
            Console.WriteLine("■    ■      ■                  ■               ■");
            Console.WriteLine("■    ■      ■                  ■               ■");
            Console.WriteLine("■    ■  ■■■■■■■■        ■             ■■");
        }
    }
}
