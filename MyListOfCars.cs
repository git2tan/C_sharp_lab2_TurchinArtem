using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem
{
    class MyListOfCars
    {
        private List<Car> cars = new List<Car>();
        //конструкторы
        public MyListOfCars()
        {

        }
        public MyListOfCars(Car firstCar)
        {
            cars.Add(firstCar);
        }
        //пользвательские методы
        public void AddCar(Car car)
        {
            cars.Add(car);
        }
        public void RemoveCar(int indx)
        {
            try
            {
                cars.RemoveAt(indx);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при удалении из списка!");
            }
        }
        public void ShowCars()
        {
            int indx = 0;
            foreach(var each in cars)
            {
                Console.WriteLine("[{0}] - {1}",indx,each.ToStringWithoutRepDates());
            }
        }
    }

}
