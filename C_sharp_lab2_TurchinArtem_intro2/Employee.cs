using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem_intro2
{
    class Employee
    {
        private string fullName;
        private int empID;
        private int currPay;
        
        public Employee(string fullName, int empID, int currPay)
        {
            this.fullName = fullName;
            this.empID = empID;
            this.currPay = currPay;
        }
        public void GiveBonus(int bonus)
        {
            currPay += bonus;
        }
        public virtual void DisplayStats()
        {
            Console.WriteLine("Name:{0}", fullName);
            Console.WriteLine("Pay:{0}", currPay);
            Console.WriteLine("ID:{0}", empID);
        }
    }
}
