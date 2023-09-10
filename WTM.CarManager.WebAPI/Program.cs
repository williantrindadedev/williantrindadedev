using Microsoft.EntityFrameworkCore;
using WTM.CarManager.Business.Interfaces;
using WTM.CarManager.Business.Services;
using WTM.CarManager.Infrasctructure.Contexts;
using WTM.CarManager.Infrasctructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//INJEÇÃO DE DEPENDÊNCIA
//builder.Services.AddSingleton<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
//builder.Services.AddTransient<IBrandRepository, BrandRepository>();
var conn = @"Server=(localdb)\mssqllocaldb;Database=SoCarroVeiculos;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conn));

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
