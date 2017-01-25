using System;

namespace C_sharp_lab2_TurchinArtem
{
    class Program
    {
        static void Main(string[] args)
        {
            CargoCar myCargoCar = new CargoCar();
            myCargoCar.RepairNow("ремонт подвески", 12000);
            Console.WriteLine(myCargoCar);
            CargoCar myCargoCarBentley = new CargoCar(Marks.bentley,450,9000000,0.15);
            Console.WriteLine("-------------------");
            Console.WriteLine(myCargoCarBentley);
            
            myCargoCarBentley.ShowLikeImage();
            myCargoCarBentley.ShowLikeText();
            Console.WriteLine("-------------------");
            Console.WriteLine(myCargoCar);
            myCargoCar.ShowLikeImage();
            myCargoCar.ShowLikeText();

            myCargoCar.DriveOneMile(myCargoCarBentley);
            Console.ReadKey();
            //GUI.work();
            Console.WriteLine("-----------------------------------------------------------");
            CargoCar car1 = new CargoCar(Marks.bentley, 400, 12000000, 1);
            CargoCar car2 = new CargoCar(Marks.mitsubishi, 150, 900000, 10);
            car2.RepairNow("Ремонт подвески1", 12000);
            car2.RepairNow("Ремонт подвески2", 17000);
            car2.RepairNow("Перегретый двигатель", 100000);
            Console.WriteLine(car1);
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine(car2);
            car2.ListOfRepairsDate[1].Works = "Новые работы";
            car2.ListOfRepairsDate[0].Date = new DateTime(2018,10,11);
            car2.ListOfRepairsDate[2].Cost = 9999;
            Console.WriteLine("После изменения:\n"+car2);
            Console.ReadLine();
        }
    }
}
