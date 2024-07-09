using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Reciep
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food food { get; set; }
        public int ProductId { get; set; }
        public string Unit { get; set; }
        public Product product { get; set; }
        public double CountPoduct { get; set; }
    }
}
