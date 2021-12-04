using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Models
{
    public class Oil
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Oil(string name)
        {
            Name = name;
        }

        public Oil()
        {
        }

    }
}