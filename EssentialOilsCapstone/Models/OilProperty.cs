using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Models
{
    public class OilProperty
    {
        public int TreatmentId { get; set; }
        public int OilId { get; set; }
        public Oil Oil { get; set; }
        public Property Treatment { get; set; }

        public OilProperty()
        {
        }
    }
}
