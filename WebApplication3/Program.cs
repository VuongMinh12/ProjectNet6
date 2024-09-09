using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Respository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
    policy =>
        {
            policy.AllowAnyOrigin().WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        });
});


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
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("MyAllowSpecificOrigins");  

app.UseAuthorization();

app.MapControllers();

app.Run();
