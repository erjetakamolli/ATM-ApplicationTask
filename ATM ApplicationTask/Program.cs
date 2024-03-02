using ATM_AplicationTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ATMDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-NKV6MM8;Initial Catalog=ATMDatabase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddDbContext<ATMDbContext>
  (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ATMDbConnection")));


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
