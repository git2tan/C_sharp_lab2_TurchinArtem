using System;
using System.Collections.Generic;

namespace C_sharp_lab2_TurchinArtem
{
    abstract class Car:ITuningable
    {
        private Marks marka;    //марка авто (перечислитель)
        private int power;      //мощность авто
        private double price;   //цена авто
        private List<DateOfRepair> listOfRepairsDate= new List<DateOfRepair>(); //список проводивщихся ремонтов и соотв дат
        //Конструкторы
        public Car()    //без параметров, по умолчанию
        {
            marka = Marks.toyota;
            power = 100;
            price = 320020;     //цену установим как 320020
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
        //Индексатор
        public DateOfRepair this[int i] //ReadOnly!!!
        {
            get
            {
                if (i >= 0 && listOfRepairsDate.Count > 0)
                    return listOfRepairsDate[i];
                else
                    return null;
            }
        }
        //пользовательские методы
        abstract public void DriveOneMile(Car car);
        abstract public double Acceleration();
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
        public virtual string ToStringWithoutRepDates()
        {
            string s;
            s = String.Format("[марка: {0}], [мощность: {1}л.с], [цена: {2:N} руб].", marka, power, price);
            return s;
        }
        public void Tuning(int increaseEnginByPercent, int price)
        {
            if (increaseEnginByPercent > 100)
                throw new TuningException("Нельзя увеличить базовую мощность более чем на 100%!!!");
            int deltaPower = power * increaseEnginByPercent / 100;
            power = power + deltaPower;
            string s = String.Format("Мощность двиг-ля увел. с {0}л.с на {1}л.с. до {2}л.с.!", this.Power, deltaPower, power);
            listOfRepairsDate.Add(new DateOfRepair(DateTime.Now, s, price));
        }
    }
}
