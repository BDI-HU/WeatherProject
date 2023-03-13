using BackendBDI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(10, 9, 3));
var config = builder.Configuration;

builder.Services.AddDbContextPool<ApplicationDbContext>(dbContextOptions => dbContextOptions
    .UseMySql(config.GetConnectionString("DefaultConnection"), serverVersion)
    // The following three options help with debugging, but should
    // be changed or removed for production.
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();