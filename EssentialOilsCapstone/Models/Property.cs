using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Property(string name)
        {
            Name = name;
        }

        public Property()
        {

        }
    }
}