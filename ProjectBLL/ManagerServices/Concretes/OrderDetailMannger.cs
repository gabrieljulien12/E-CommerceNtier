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
    public class OrderDetailMannger:BaseManager<OrderDetail>,IOrderDetailManger
    {
        IOrderDetailRepository _detail;
        public OrderDetailMannger( IOrderDetailRepository detail):base(detail)
        {
            _detail = detail;
        }
    }
}
