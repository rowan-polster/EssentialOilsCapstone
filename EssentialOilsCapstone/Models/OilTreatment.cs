using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Essential_Oil_Capstone.Models
{
    public class OilTreatment
    {
        public int TreatmentId { get; set; }
        public int OilId { get; set; }
        public Oil Oil { get; set; }
        public Treatment Treatment { get; set; }

        public OilTreatment()
        {
        }
    }
}
