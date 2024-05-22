using Entıtıes.Models;
using ProjectBLL.ManagerServices.Abstracs;
using ProjectDAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.ManagerServices.Concretes
{
    public class AppUserManger:BaseManager<AppUser>,IAppUserManger
    {
        IAppUserRepositorty _iaprep;
        public AppUserManger(IAppUserRepositorty aprep):base(aprep)
        {
                _iaprep = aprep;
        }

        public async Task<bool> CreateUser(AppUser item)
        {
            
            return await _iaprep.AddUser(item);
        }
    }
}
