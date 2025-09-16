using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroerviceOrnegi.Order.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<MicroerviceOrnegi.Order.Domain.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasMany(x => x.OrderItems).WithOne(x=>x.Order).HasForeignKey(x => x.OrderId);

            builder.HasOne(x=>x.Address).WithMany().HasForeignKey(x => x.AddressId);
        }
    }
}
