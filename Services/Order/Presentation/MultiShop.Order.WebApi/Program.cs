using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistance.Context;
using MultiShop.Order.Persistance.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderContext>();
// Generic Repository Tan�mlama
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Application Service Ba�lant�s� (E�er �zel bir extension method ise do�ru �al��t���ndan emin ol)
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

// Swagger Konfig�rasyonu
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geli�tirme Ortam� ��in Swagger Aktifle�tirme
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Konfig�rasyonu
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
