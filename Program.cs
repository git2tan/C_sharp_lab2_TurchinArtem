using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(Marks.bentley, 500, 10000000);
            Console.WriteLine(myCar);
            Console.Write("\n");
            myCar.RepairNow("перегретый двигатель", 1000000);
            myCar.RepairByDate(new DateTime(2016, 09, 01, 18, 25, 11), "Замена масла", 70000);
            Console.WriteLine(myCar);
            Console.Write("\nПосле Тюнинга:\n");
            myCar.Tuning(20, 1500000);
            myCar.RepairNow("Замена масла и колодок", 50000);
            Console.WriteLine(myCar);
            Console.WriteLine("Стер 2 запись о ремонте...");
            myCar.RemoveRepairDate(2);
            Console.WriteLine(myCar);
            Console.ReadKey();
            
            GUI.work();
        }
    }
}
