using Backend.Context;
using Backend.Repositories;
using Backend.Repository;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseSqlServer(ConnectionString));

#region Repositories
builder.Services.AddScoped<IUserTypeRepository, UserTypesRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
#endregion
#region Services
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
