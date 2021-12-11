﻿using EssentialOilsCapstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.ViewModels
{
    public class OilDetailViewModel
    {

        public int OilId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PropertyText { get; set; }

        public OilDetailViewModel(Oil theOil, List<OilProperty> oilProperties)
        {
            OilId = theOil.Id;
            Name = theOil.Name;
            Description = theOil.Description;

            PropertyText = "";
            for (int i = 0; i < oilProperties.Count; i++)
            {
                PropertyText += oilProperties[i].Property.Name;
                if (i < oilProperties.Count - 1)
                {
                    PropertyText += ", ";
                }
            }
        }
    }
}

