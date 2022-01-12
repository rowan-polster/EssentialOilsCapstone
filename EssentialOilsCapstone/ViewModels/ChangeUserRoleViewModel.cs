using EssentialOilsCapstone.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.ViewModels
{
    public class ChangeUserRoleViewModel
    {
        public string UserId { get; set; }
        public List<SelectListItem> Users { get; set; }

        public string RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }

        public ChangeUserRoleViewModel(List<EssentialOilsCapstoneUser> users, List<IdentityRole> roles)
        {
            Users = new List<SelectListItem>();
            Roles = new List<SelectListItem>();

            foreach (EssentialOilsCapstoneUser user in users)
            {
                Users.Add(
                    new SelectListItem
                    {
                        Value = user.Id.ToString(),
                        Text = user.UserName
                    });
            }

            foreach (IdentityRole role in roles)
            {
                Roles.Add(
                    new SelectListItem
                    {
                        Value = role.Id.ToString(),
                        Text = role.Name
                    });
            }
        }

        public ChangeUserRoleViewModel()
        {

        }
    }
}
