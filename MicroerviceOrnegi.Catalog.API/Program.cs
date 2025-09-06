using MicroerviceOrnegi.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptionsExt();

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

