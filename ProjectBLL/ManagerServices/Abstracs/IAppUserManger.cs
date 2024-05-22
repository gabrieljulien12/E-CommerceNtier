using Entıtıes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.ManagerServices.Abstracs
{
    public interface IAppUserManger:IManeger<AppUser>
    {
        Task<bool>CreateUser(AppUser item);
    }
}
