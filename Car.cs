using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem
{
    class Car:ITuningable
    {
        private Marks marka;
        private int power;
        private double price;
        private List<DateOfRepair> listOfRepairsDate= new List<DateOfRepair>();
        //Конструкторы
        public Car()
        {
            marka = Marks.toyota;
            power = 100;
            price = 320020;
        }
        public Car(Marks marka, int power, double price)
        {
            this.marka = marka;
            this.power = power;
            this.price = price;
        }
        //свойства
        public int Power
        {
            set { power = value; }
            get { return power; }
        }
        public double Price
        {
            set { price = value; }
            get { return price; }
        }
        public Marks Marka
        {
            set { marka = value; }
            get { return marka; }
        }
        public List<DateOfRepair> ListOfRepairsDate
        {
            set { listOfRepairsDate = value; }
            get { return listOfRepairsDate; }
        }
        //пользовательские методы
        public void RepairNow(string works, int cost)
        {
            DateOfRepair tmpDateOfRepair = new DateOfRepair(DateTime.Now,works, cost);
            listOfRepairsDate.Add(tmpDateOfRepair);
        }
        public void RepairByDate(DateTime dateOfRepair, string works, int cost)
        {
            DateOfRepair tmpDateOfRepair = new DateOfRepair(dateOfRepair, works, cost);
            listOfRepairsDate.Add(tmpDateOfRepair);
        }
        public DateOfRepair RemoveRepairDate(int indx)
        {
            DateOfRepair tmpDateOfRepair;
            try
            {
                tmpDateOfRepair = listOfRepairsDate[indx];
                listOfRepairsDate.RemoveAt(indx);
            }
            catch (Exception)
            {
                Console.WriteLine("Пользовательское исключение");
                tmpDateOfRepair = null;
            }
            return tmpDateOfRepair;
        }
        //наследуемые и перегруженные методы
        public override string ToString()
        {
            string s = String.Format("[марка: {0}], [мощность: {1}л.с], [цена: {2:N} руб].\nДаты ремонта:", marka, power, price);
            //s = s + "[Марка - " + marka + "], [мощность - " + power + "л.с.], [цена - " + price + "руб].\nДаты ремонта:";

            if (listOfRepairsDate.Count > 0)
            {
                int indx = 0;
                foreach (var each in listOfRepairsDate)
                {
                    s += "\n" + "[" + indx + "]";
                    s += each.ToString();
                    indx++;
                }
            }
            else
            {
                s += "не ремонтировалась";
            }
            return s;
        }
        public string ToStringWithoutRepDates()
        {
            string s;
            s = String.Format("[марка: {0}], [мощность: {1}л.с], [цена: {2:N} руб].", marka, power, price);
            return s;
        }
        public void Tuning(int increaseEnginByPercent, int price)
        {
            int deltaPower = power * increaseEnginByPercent / 100;
            power = power + deltaPower;
            string s = String.Format("Мощность двиг-ля увел. с {0}л.с на {1}л.с. до {2}л.с.!", this.Power, deltaPower, power);
            //this.Price += price;
            listOfRepairsDate.Add(new DateOfRepair(DateTime.Now, s, price));
        }
    }
}
