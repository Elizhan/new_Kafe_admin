using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Check
    {
        public int Id { get; set; }
        public int CheckCount { get; set;}
        public int TableId { get; set; }
        public Table table { get; set; }
        public DateTime DateTimeCheck { get; set; }
        public int WaiterId { get; set; }
        public Waiter waiter { get; set; }
        public int Status { get; set; }
        public int GuestsCount { get; set; }


    }
}
