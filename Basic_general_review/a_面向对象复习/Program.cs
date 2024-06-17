using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_面向对象复习
{
    class Program
    {
        static void Main(string[] args)
        {
            //this
            //new
            //1):创建对象
            //2):隐藏从父类那里继承过来的成员
        }
    }

    public class Person
    {
        public void T()
        {

        }
    }

    public class Teacher : Person
    {
        public new void T()
        {

        }
    }
}
