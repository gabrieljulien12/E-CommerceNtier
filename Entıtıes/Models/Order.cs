using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entıtıes.Models
{
   public class Order:BaseEntity
    {
        public string ShipingAdres {  get; set; }

        public int? AppuserID { get; set; }

        //Relation Properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; } 

    }
}
