using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem_intro2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee first = new Employee("Joe",1,10000);
            Employee second;
            second = new Employee("Beth", 2, 20000);
            first.GiveBonus(5000);
            first.DisplayStats();
            second.DisplayStats();
            Console.ReadKey();
        }
    }
}
