using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class ReceiptGoods
    {
        public int Id { get; set; }
        public DateTime DateTimeReceiptGoods { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
    }
}
