using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.Models
{
    public class Table:StandartAbstract
    {
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [NotMapped]
        public Location TableLocation
        {
            get
            {
                return DateWorker.GetLocationById(LocationId);
            }
        }

    }
}
