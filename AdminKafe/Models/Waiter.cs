using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Waiter:StandartAbstract
    {
        public string AliasName { get; set; }
        public string Pass { get; set; }
        public string Tel { get; set; }
        public string address { get; set; }
        public string SalaryType { get; set; }
        public double Salary { get; set; }



    }
}
