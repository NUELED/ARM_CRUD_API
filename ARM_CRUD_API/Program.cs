using ARM_CRUD_API;
using ARM_CRUD_API.Data;
using ARM_CRUD_API.Services.Implementations;
using ARM_CRUD_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console() // Log to console
    .WriteTo.File("logs/staff.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddScoped<IStaffService, StaffService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("staff");
app.UseAuthorization();

app.MapControllers();

app.Run();
