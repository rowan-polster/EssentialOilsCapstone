using System;
using EssentialOilsCapstone.Areas.Identity.Data;
using EssentialOilsCapstone.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EssentialOilsCapstone.Areas.Identity.IdentityHostingStartup))]
namespace EssentialOilsCapstone.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OilDbContext>(options =>
                 options.UseMySql(
                     context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<EssentialOilsCapstoneUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddEntityFrameworkStores<OilDbContext>();
            });
        }
    }
}