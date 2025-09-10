using MongoDB.EntityFrameworkCore.Extensions;
namespace MicroerviceOrnegi.Discount.API.Repositories
{
    public class DiscountConfiguration : IEntityTypeConfiguration<MicroerviceOrnegi.Discount.API.Features.Discounts.Discount>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MicroerviceOrnegi.Discount.API.Features.Discounts.Discount> builder)
        {
            builder.ToCollection("discounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasElementName("code").HasMaxLength(50);
            builder.Property(x => x.UserId).HasElementName("user_id");
            builder.Property(x => x.Created).HasElementName("created");
            builder.Property(x => x.Updated).HasElementName("updated");
            builder.Property(x => x.Expired).HasElementName("expired");
            builder.Property(x => x.Rate).HasElementName("rate");
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
