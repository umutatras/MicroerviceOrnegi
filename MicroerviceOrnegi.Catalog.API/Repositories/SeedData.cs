using MicroerviceOrnegi.Catalog.API.Features.Categories;
using MicroerviceOrnegi.Catalog.API.Features.Courses;

namespace MicroerviceOrnegi.Catalog.API.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataExt(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new(){Id=Guid.NewGuid(),Name="Development"
                    },
                    new(){Id=Guid.NewGuid(),Name="Business"
                    },
                    new(){Id=Guid.NewGuid(),Name="IT & Software"
                    },
                    new(){Id=Guid.NewGuid(),Name="Design"
                    }

                };

                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Courses.Any())
            {
                var categories = await dbContext.Categories.FirstAsync();

                List<Course> courses = new()
                {
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Name="Complete C# Masterclass",
                        Description="Learn C# from scratch to advanced level with practical examples and projects.",
                        Price=49.99M,
                        ImageUrl="https://example.com/images/csharp.jpg",
                        CategoryId=categories.Id,
                        UserId=Guid.NewGuid(),
                        Created=DateTime.Now
                    },
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Name="Business Analytics Fundamentals",
                        Description="Understand the basics of business analytics and how to apply it in real-world scenarios.",
                        Price=39.99M,
                        ImageUrl="https://example.com/images/business-analytics.jpg",
                        CategoryId=categories.Id,
                         UserId=Guid.NewGuid()
                         ,Created=DateTime.Now
                    },
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Name="Introduction to Networking",
                        Description="Learn the fundamentals of computer networking, including protocols, topologies, and security.",
                        Price=29.99M,
                        ImageUrl="https://example.com/images/networking.jpg",
                        CategoryId=categories.Id,
                        UserId=Guid.NewGuid(),
                        Created=DateTime.Now
                    },
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Name="Graphic Design Basics",
                        Description="Get started with graphic design using popular tools like Adobe Photoshop and Illustrator.",
                        Price=34.99M,
                        ImageUrl="https://example.com/images/graphic-design.jpg",
                        CategoryId=categories.Id,
                        UserId=Guid.NewGuid(),
                        Created=DateTime.Now
                    }
                };

                dbContext.Courses.AddRange(courses);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
