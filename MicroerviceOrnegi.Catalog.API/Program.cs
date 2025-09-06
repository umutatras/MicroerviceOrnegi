using MicroerviceOrnegi.Catalog.API.Options;
using MicroerviceOrnegi.Catalog.API.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

