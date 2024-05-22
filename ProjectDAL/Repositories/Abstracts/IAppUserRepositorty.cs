using Entıtıes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Repositories.Abstracts
{
    public interface IAppUserRepositorty:IRepository<AppUser>
    {
        Task<bool> AddUser(AppUser item);

    }
}
