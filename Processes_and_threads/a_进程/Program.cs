using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_进程
{
    class Program
    {
        static void Main(string[] args)
        {
            //进程
            //我们可以把计算机中每一个运行的应用程序都当做是一个进程。
            //而一个进程又是由多个线程组成的。


            //获得当前程序中所有正在运行的进程
            //Process[] pros = Process.GetProcesses();
            //foreach (var item in pros)
            //{
            //    //不试的不是爷们儿
            //    //item.Kill();
            //   // Console.WriteLine(item);
            //}
            //Console.ReadKey();


            //通过进程打开一些应用程序
            //Process.Start("calc");
            //Process.Start("mspaint");
            //Process.Start("notepad");
            //Process.Start("iexplore", "http://www.baidu.com");

            //通过一个进程打开指定的文件

            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Users\Marguba\Desktop\asd.txt");

            //第一：创建进程对象
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            ////p.StartInfo

            //Console.ReadKey();
        }
    }
}
