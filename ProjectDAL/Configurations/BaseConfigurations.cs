using Entıtıes.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Configurations
{
    public abstract class BaseConfigurations<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public  virtual void Configure(EntityTypeBuilder<T> builder)
        {
            
        }
    }
}
