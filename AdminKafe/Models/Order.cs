using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food food { get; set; }
        public int CheckId { get; set; }
        public Check check { get; set; }
        public int CountFood { get; set; }

    }
}
