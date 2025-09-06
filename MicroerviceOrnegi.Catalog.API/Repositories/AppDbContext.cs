using MicroerviceOrnegi.Catalog.API.Features.Categories;
using MicroerviceOrnegi.Catalog.API.Features.Courses;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MicroerviceOrnegi.Catalog.API.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
