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
    public class AppUserProfileManager:BaseManager<AppUserProfile>,IAppUserProfileManager
    {
        IAppUserProfileRepository _profile;
        public AppUserProfileManager( IAppUserProfileRepository profile):base(profile)
        {
            _profile = profile;
        }
    }
}
