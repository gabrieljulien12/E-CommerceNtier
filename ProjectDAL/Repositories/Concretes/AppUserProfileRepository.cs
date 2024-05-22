using Entıtıes.Models;
using ProjectDAL.Context;
using ProjectDAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Repositories.Concretes
{
    public class AppUserProfileRepository:BaseRepository<AppUserProfile>,IAppUserProfileRepository
    {
        public AppUserProfileRepository(MyContext db):base(db)
        {
            
        }
    }
}
