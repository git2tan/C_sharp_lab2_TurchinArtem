using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem_intro3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Fam = "Петров";
            p1.Age = 21;
            p1.Salary = 10000;
            Console.WriteLine("ФАмилия:{0} возраст{1} статус{2}",p1.Fam,p1.Age,p1.Status);
            Console.ReadKey();
        }
    }
}
