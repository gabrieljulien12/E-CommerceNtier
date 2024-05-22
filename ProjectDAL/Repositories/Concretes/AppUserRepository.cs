using Entıtıes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using ProjectDAL.Context;
using ProjectDAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Repositories.Concretes
{
    public class AppUserRepository:BaseRepository<AppUser>,IAppUserRepositorty
    {
        UserManager<AppUser> _usermanager;
       
        public AppUserRepository(MyContext db,UserManager<AppUser> userManager ):base(db)
        {
            _usermanager = userManager;
            
        }
        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result =await _usermanager.CreateAsync(item,item.PasswordHash);
            if( result.Succeeded) return true;
            return false;
        }
    }
}
