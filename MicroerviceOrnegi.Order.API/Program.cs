using MicroerviceOrnegi.Bus;
using MicroerviceOrnegi.Order.API.Endpoints.Orders;
using MicroerviceOrnegi.Order.Application;
using MicroerviceOrnegi.Order.Application.BackgroundServices;
using MicroerviceOrnegi.Order.Application.Conracts.Refit;
using MicroerviceOrnegi.Order.Application.Conracts.Repositories;
using MicroerviceOrnegi.Order.Application.Conracts.UnitOfWork;
using MicroerviceOrnegi.Order.Persistence;
using MicroerviceOrnegi.Order.Persistence.Repositories;
using MicroerviceOrnegi.Order.Persistence.UnitOfWork;
using MicroerviceOrnegi.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCommonServiceExt(typeof(OrderApplicationAssembly));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCommonMasstransitExt(builder.Configuration);
builder.Services.AddHostedService<CheckPaymentStatusOrderBackgroundService>();
builder.Services.AddVersioningExt();
builder.Services.AddAuthenticationAndAuthorizationExt(builder.Configuration);
builder.Services.AddRefitConfigurationExt(builder.Configuration);
var app = builder.Build();
app.AddOrderGroupEndpointExt(app.AddVersionSetExt());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();

