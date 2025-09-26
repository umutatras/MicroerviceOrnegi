using Microsoft.EntityFrameworkCore;

namespace MicroerviceOrnegi.Payment.API.Repositories
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.OrderCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Created).IsRequired();

            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Payment> Payments { get; set; }
    }
}
