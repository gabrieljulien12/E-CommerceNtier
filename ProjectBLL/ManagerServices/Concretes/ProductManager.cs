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
    public class ProductManager:BaseManager<Product>,IProductManager
    {
        IProductRepository _product;
        public ProductManager( IProductRepository product):base(product)
        {
            _product=product;
        }
    }
}
