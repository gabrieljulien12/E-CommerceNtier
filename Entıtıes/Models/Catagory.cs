using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entıtıes.Models
{
    public class Catagory:BaseEntity
    {
        public string CatagoryName { get; set; }
        public string Description { get; set; }
        //Relations Properteis

        public virtual List<Product> Products { get; set; }

    }
}
