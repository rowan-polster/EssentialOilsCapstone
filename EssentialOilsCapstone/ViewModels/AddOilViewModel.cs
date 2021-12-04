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
        [Required(ErrorMessage = "Essential oil name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        /*[Required(ErrorMessage = "At least 2 properties are required.")]
        [MinChecked(2)]*/
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
