using Entıtıes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProjectDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.DependencyResolves
{
    public static class IdentityExtasionServices
    {
        public static IServiceCollection AddIdentityService( this IServiceCollection services )
        {
           services.AddIdentity<AppUser, IdentityRole<int>>(x =>
           {
               x.Password.RequiredLength = 3;
               x.Password.RequiredUniqueChars = 0;
               x.Password.RequireNonAlphanumeric = false;
               x.Password.RequireDigit = false;
               x.Password.RequireLowercase = false;
               x.Password.RequireUppercase = false;
           }).AddEntityFrameworkStores<MyContext>();
            return services;
        }
    }
}
