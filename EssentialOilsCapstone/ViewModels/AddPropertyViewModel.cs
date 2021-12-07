using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.ViewModels
{
    public class AddPropertyViewModel
    {
/*        [Required(ErrorMessage = "Property name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long.")]*/
        public string Name { get; set; }

        public AddPropertyViewModel(string name)
        {
            Name = name;
        }

        public AddPropertyViewModel()
        {
        }
    }
}
