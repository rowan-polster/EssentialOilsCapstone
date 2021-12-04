using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Models
{
    public class OilProperty
    {
        public int PropertyId { get; set; }
        public int OilId { get; set; }
        public Oil Oil { get; set; }
        public Property Property { get; set; }

        public OilProperty()
        {
        }
    }
}
