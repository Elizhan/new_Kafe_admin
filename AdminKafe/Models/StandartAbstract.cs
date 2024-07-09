using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class StandartAbstract : IStandartClasss
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
