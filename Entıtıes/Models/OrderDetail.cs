using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entıtıes.Models
{
    public class OrderDetail:BaseEntity
    {
        public int ProductID { get; set; }
        public int OrdersID { get; set; }
        public int Quanitly { get; set; }

        //Relations Properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
