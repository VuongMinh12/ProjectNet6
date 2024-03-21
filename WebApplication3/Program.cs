using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<KeyboardContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("KeyboardDbContext")));


builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IBrandRespository, BrandRespository>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
