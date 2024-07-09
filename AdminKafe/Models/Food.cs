using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Food:StandartAbstract
    {
       public double Price { get; set; }
       public byte[] Image { get; set; }
       public int ParentCategoryId { get; set; }
       public int isCook { get; set; }
    }
}
