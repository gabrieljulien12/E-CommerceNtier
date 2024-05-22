using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entıtıes.Models
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryID { get; set; }

        //Relations Properties
        public virtual Catagory Catagory { get; set; }  
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
