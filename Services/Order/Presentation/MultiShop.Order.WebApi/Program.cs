using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistance.Context;
using MultiShop.Order.Persistance.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderContext>();
// Generic Repository Tanýmlama
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Application Service Baðlantýsý (Eðer özel bir extension method ise doðru çalýþtýðýndan emin ol)
builder.Services.AddApplicationService(builder.Configuration);

// Address Servisleri
builder.Services.AddScoped<GetAdressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();

// OrderDetail Servisleri
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();

// Controller Servisleri
builder.Services.AddControllers();

// Swagger Konfigürasyonu
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geliþtirme Ortamý Ýçin Swagger Aktifleþtirme
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Konfigürasyonu
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
