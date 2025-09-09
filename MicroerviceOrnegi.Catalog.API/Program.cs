using MicroerviceOrnegi.Catalog.API;
using MicroerviceOrnegi.Catalog.API.Features.Categories;
using MicroerviceOrnegi.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.AddCategoryGroupEndpointExt();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

