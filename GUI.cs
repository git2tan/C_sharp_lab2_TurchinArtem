using System;
using System.Collections.Generic;

namespace C_sharp_lab2_TurchinArtem
{
    class GUI
    {
        enum menu1 : int { exit, show, remove, allAboutOneCar, autoFillGarage, repair, editRepairDates,changePrice, changeMark, TUNING, other }
        static List<Car> garage = new List<Car>();
        public static void work()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                Console.WriteLine("выберите один из пунктов меню");
                Console.WriteLine("1-{0}\n2-{1}\n3-{2}\n4-{3}\n5-{4}\n6-{5}\n7-{6}\n8-{7}\n9-{8}\n0-{9}", menu1.show, menu1.remove, menu1.allAboutOneCar, 
                    menu1.autoFillGarage, menu1.repair, menu1.editRepairDates, menu1.changePrice, menu1.changeMark, menu1.TUNING, menu1.exit);
                menu1 menu1Choise;
                try
                {
                    menu1Choise = (menu1)int.Parse(Console.ReadLine());
                }
                catch
                {
                    menu1Choise = menu1.other;
                }
                switch (menu1Choise)
                {
                    case menu1.exit:
                        isExit = true; break;
                    case menu1.show:
                        GUI.ShowCars();
                        System.Threading.Thread.Sleep(1000); break;
                    case menu1.autoFillGarage:
                        GUI.AutoFillGarage(); break;
                    case menu1.allAboutOneCar:
                        GUI.ShowAllAboutOneCar(); break;
                    case menu1.remove:
                        GUI.Remove(); break;
                    case menu1.editRepairDates:
                        GUI.EditRepairDates(); break;
                    case menu1.repair:
                        GUI.Repair();break;
                    case menu1.changePrice:
                        GUI.ChangePrice();break;
                    case menu1.changeMark:
                        GUI.ChangeMark();break;
                    case menu1.TUNING:
                        GUI.Tuning();break;
                    default:
                        Console.WriteLine("Неправильный пункт меню");
                        System.Threading.Thread.Sleep(500); break;
                }

            }
        }

        

        public static void ShowCars()
        {
            Console.WriteLine("вывожу тачки:");
            int i = 0;
            foreach (var each in garage)
            {
                Console.WriteLine("[" + i + "] - " + each.ToStringWithoutRepDates());
                i++;
            }
            if (i==0)
            {
                Console.WriteLine("Гараж пустой.");
            }
            //System.Threading.Thread.Sleep(3000);
            //Console.ReadKey();
        }
        public static void ShowAllAboutOneCar()
        {
            GUI.ShowCars();
            Console.WriteLine("Введите номер автомобиля о котором вы хотите узнать подробности.");
            int indx = int.Parse(Console.ReadLine());
            Console.WriteLine(garage[indx]);
            //System.Threading.Thread.Sleep(3000);
            Console.ReadKey();
        }
        public static void AutoFillGarage()
        {
            Console.WriteLine("Сколько машин создаем?");
            int count = int.Parse(Console.ReadLine());
            if (count > 0)
            {

                Random realRnd = new Random();
                for (; count > 0; count--)
                {
                    Car tmpCar = new Car((Marks)realRnd.Next(4), realRnd.Next(75, 350), realRnd.Next(500000, 3000000) + realRnd.NextDouble());
                    garage.Add(tmpCar);
                }
                Console.WriteLine("Гараж заполнен!");
                System.Threading.Thread.Sleep(1000);
            }

        }
        public static void Remove()
        {
            GUI.ShowCars();
            Console.WriteLine("введите номер удаляемого авто");
            int indx = int.Parse(Console.ReadLine());
            if (indx < garage.Count)
            {
                garage.RemoveAt(indx);
            }
            else
            {
                Console.WriteLine("Гараж пустой или ошибка индекса");
            }
            GUI.ShowCars();
            Console.ReadKey();
        }
        public static void EditRepairDates()
        {
            
            GUI.ShowCars();
            Console.WriteLine("Введите номер автомобиля о котором вы хотите узнать подробности.");
            int indx = int.Parse(Console.ReadLine());
            Console.WriteLine(garage[indx]);

            Console.WriteLine("Вы хотите удалить(0) или добавить(1) запись о ремонте уу данного авто?");
            bool choise = int.Parse(Console.ReadLine()) == 0 ? true : false;
            if (choise)
            {
                if (garage[indx].ListOfRepairsDate.Count > 1)
                {
                    Console.WriteLine("Введите индекс удаляемой записи");
                    int indxOfRemove = int.Parse(Console.ReadLine());
                    garage[indx].RemoveRepairDate(indxOfRemove);
                }
                else if (garage[indx].ListOfRepairsDate.Count == 1)
                {
                    Console.WriteLine("Вы хотите удалить единственную запись о ремонте");
                    garage[indx].RemoveRepairDate(0);
                }

            }
            else
            {
                Console.WriteLine("Введите дату ремонта: в формате YYYY[ввод]MM[ввод]D[ввод]");
                int tmpYear = int.Parse(Console.ReadLine());
                int tmpMonth = int.Parse(Console.ReadLine());
                int tmpDay = int.Parse(Console.ReadLine());
                DateTime tmpDate = new DateTime(tmpYear, tmpMonth, tmpDay);
                Console.WriteLine("Удалось! Теперь опишите - какие рабоы производились:");
                string tmpWorks = Console.ReadLine();
                Console.WriteLine("Введите стоимость ремонта");
                int tmpCost = int.Parse(Console.ReadLine());
                garage[indx].RepairByDate(tmpDate, tmpWorks, tmpCost);
            }
            Console.WriteLine("Отредактированная запись");
            Console.WriteLine(garage[indx]);
            Console.ReadKey();
        }
        public static void Repair()
        {
            GUI.ShowCars();
            Console.WriteLine("Введите номер автомобиля который вы отремонтировали.");
            int indx = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Опишите - какие рабоы производились:");
            string tmpWorks = Console.ReadLine();
            Console.WriteLine("Введите стоимость ремонта");
            int tmpCost = int.Parse(Console.ReadLine());
            garage[indx].RepairNow(tmpWorks, tmpCost);
            Console.WriteLine("Отредактированная запись");
            Console.WriteLine(garage[indx]);
            Console.ReadKey();
        }
        public static void ChangePrice()
        {
            if (garage.Count > 0)
            {
                GUI.ShowCars();
                Console.WriteLine("Введите номер автомобиля у которого вы редактируете цену.");
                int indx = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите новвую цену:");
                int newPrice = int.Parse(Console.ReadLine());
                garage[indx].Price = newPrice;
                Console.WriteLine("отредактированная запись:\n" + garage[indx].ToStringWithoutRepDates());
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ваш гараж пустой!");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void ChangeMark()
        {
            if (garage.Count > 0)
            {
                GUI.ShowCars();
                Console.WriteLine("Введите номер автомобиля у которого вы редактируете марку.");
                int indx = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите новвую марку где:\n0-{0},1-{1},2-{2},3-{3},4-{4}", Marks.audi,Marks.bentley, Marks.bmw, Marks.mazda, Marks.toyota);
                Marks newMarka = (Marks)int.Parse(Console.ReadLine());
                if((int)newMarka>4)
                    garage[indx].Marka = Marks.toyota;
                else
                    garage[indx].Marka = newMarka;
                Console.WriteLine("Отредактированная запись:\n" + garage[indx].ToStringWithoutRepDates());
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ваш гараж пустой!");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void Tuning()
        {
            GUI.ShowCars();
            Console.WriteLine("Тюнигуем тачку! Которую?");
            int indx = int.Parse(Console.ReadLine());
            if(indx<garage.Count)
            {
                Console.WriteLine("введите на сколько увеличиваете мощность в %.");
                int percent = int.Parse(Console.ReadLine());
                Console.WriteLine("И сколько стоит?");
                int cost = int.Parse(Console.ReadLine());
                garage[indx].Tuning(percent, cost);
                Console.WriteLine(garage[indx]);
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Индекс не корректен или гараж пустой...");
                System.Threading.Thread.Sleep(500);
            }

        }
    }
}
