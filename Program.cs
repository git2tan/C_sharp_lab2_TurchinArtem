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
        }
    }
}
