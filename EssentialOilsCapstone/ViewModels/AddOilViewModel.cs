using EssentialOilCapstone.Models;
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

        public List<SelectListItem> Treatments { get; set; }

        public AddOilViewModel(List<Treatment> treatments)
        {
            Treatments = new List<SelectListItem>();

            foreach (Treatment treatment in treatments)
            {
                Treatments.Add(
                    new SelectListItem
                    {
                        Value = treatment.Id.ToString(),
                        Text = treatment.Name
                    });
            }
        }

        public AddOilViewModel()
        {

        }
    }
}
