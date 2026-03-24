using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AuthService.Infrastructure;
using AuthService.Application;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer("Server=sqlserver;Database=AuthDb;User=sa;Password=Your_password123;"));

// DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();