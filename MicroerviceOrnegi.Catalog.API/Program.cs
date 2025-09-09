using MicroerviceOrnegi.Catalog.API;
using MicroerviceOrnegi.Catalog.API.Features.Categories;
using MicroerviceOrnegi.Catalog.API.Features.Courses;
using MicroerviceOrnegi.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.AddSeedDataExt().ContinueWith(x =>
{
    if (x.IsFaulted)
    {
        Console.WriteLine("Error adding seed data: " + x.Exception?.GetBaseException().Message);
    }
    else
    {

        Console.WriteLine("Seed data added.");
    }
});
app.AddCategoryGroupEndpointExt();
app.AddCourseGroupEndpointExt();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

