using EssentialOilsCapstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.ViewModels
{
    public class AddOilViewModel
    {
/*        [Required(ErrorMessage = "Essential oil name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]*/

        public string Name { get; set; }

/*        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 characters.")]*/

        public string Description { get; set; }

        public List<Property> Properties { get; set; }

        public AddOilViewModel(List<Property> properties)
        {
            Properties = properties;

        }

        public AddOilViewModel()
        {

        }
    }
}
