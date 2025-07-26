using MarcasAutosApi.Data;
using MarcasAutosApi.Repositories;
using MarcasAutosApi.Repositories.Interfaces;
using MarcasAutosApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarcasAutosApi.Utils.Validators;
using FluentValidation;
using MarcasAutosApi.Utils.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5160);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarBrandRepository, CarBrandRepository>();
builder.Services.AddScoped<ICarBrandService, CarBrandService>();

builder.Services.AddValidatorsFromAssemblyContaining<CarBrandValidator>();
builder.Services.AddAutoMapper(typeof(CarBrandMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
