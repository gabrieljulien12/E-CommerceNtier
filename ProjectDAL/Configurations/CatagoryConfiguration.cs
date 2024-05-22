using Entıtıes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Configurations
{
    public class CatagoryConfiguration:BaseConfigurations<Catagory>
    {
        public override void Configure(EntityTypeBuilder<Catagory> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Products).WithOne(x => x.Catagory).HasForeignKey(x => x.CategoryID);
        }
    }
}
