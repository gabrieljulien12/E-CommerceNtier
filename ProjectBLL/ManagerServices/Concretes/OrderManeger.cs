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
    public class OrderManeger:BaseManager<Order>,IOrderManager
    {
        IOrderRepository _order;
        public OrderManeger(IOrderRepository order):base(order)
        {
            _order=order;
        }
    }
}
