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
    public class CatagoryManager:BaseManager<Catagory>,ICatagoryManager
    {
        ICatagoryRepository _catagory;
        public CatagoryManager( ICatagoryRepository catagory):base(catagory)
        {

            _catagory = catagory;

        }
    }
}
