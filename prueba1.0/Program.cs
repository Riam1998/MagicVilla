using Microsoft.EntityFrameworkCore;
using prueba1._0;
using prueba1._0.Datos;
using prueba1._0.Repositorio;
using prueba1._0.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//-----------------------------------------------------------------------------------------------------------
//Add services de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(option => 
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Add services para el Mapping
builder.Services.AddAutoMapper(typeof(MappingConfig));
//Add services para el Repositorio
builder.Services.AddScoped<IPruebaRepositorio, PruebaRepositorio>();
builder.Services.AddScoped<INumeroVillaRepositorio, NVillaRepositorio>();
//-----------------------------------------------------------------------------------------------------------

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
