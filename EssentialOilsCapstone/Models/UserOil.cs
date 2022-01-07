using EssentialOilsCapstone.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Models
{
    public class UserOil
    {
        public string UserId { get; set; }
        public int OilId { get; set; }
        public Oil Oil { get; set; }
        public EssentialOilsCapstoneUser User { get; set; }

        public UserOil()
        {
        }
    }
}
