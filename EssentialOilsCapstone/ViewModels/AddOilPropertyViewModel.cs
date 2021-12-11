using EssentialOilsCapstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.ViewModels
{
    public class AddOilPropertyViewModel
    {
        public int OilId { get; set; }
        public Oil Oil { get; set; }
        public List<SelectListItem> Properties { get; set; }
        public int PropertyId { get; set; }

        public AddOilPropertyViewModel()
        {
        }

        public AddOilPropertyViewModel(Oil theOil, List<Property> possibleProperties)
        {
            Properties = new List<SelectListItem>();
            foreach (Property property in possibleProperties)
            {
                Properties.Add(new SelectListItem
                {
                    Value = property.Id.ToString(),
                    Text = property.Name
                });
            }
            Oil = theOil;
        }
    }
}
