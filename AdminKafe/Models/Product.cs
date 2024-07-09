using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Product:StandartAbstract
    {

        public string Type { get; set; }
        public double Note { get; set; }
    }
}
