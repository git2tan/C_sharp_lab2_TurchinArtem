using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_lab2_TurchinArtem_intro3
{
    class Person
    {
        int age = 0, salary = 0;
        string fam="";
        string status, health;
        public string Fam
        {
            set
            {
                if (fam == "") fam = value;
            }
            get
            {
                return fam;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
        }

        public int Age
        {
            set
            {
                age = value;
                if (age < 7) status = "Ребенок";
                else if (age < 17) status = "школьник";
                else if (age < 22) status = "студент";
                else status = "служащий";
            }
            get
            {
                return age;
            }
        }

        public int Salary
        {
            set { salary = value; }
        }
    }
}
