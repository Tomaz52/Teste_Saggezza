using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SupplierService.Application.UseCases;
using SupplierService.Domain.Interfaces;
using SupplierService.Infrastructure.Data;
using SupplierService.Infrastructure.Persistence;
using SupplierService.Infrastructure.Repositories;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

//  Add Controllers
builder.Services.AddControllers();

//  Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Database (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Dependency Injection (Repositories)
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

//  Use Cases
builder.Services.AddScoped<CreateSupplierUseCase>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<CreateDeliveryUseCase>();
builder.Services.AddScoped<GetDeliveriesUseCase>();

//  JWT Authentication
var key = Encoding.ASCII.GetBytes("SUPER_SECRET_KEY_123");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

//  Swagger em dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//  Middlewares
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();