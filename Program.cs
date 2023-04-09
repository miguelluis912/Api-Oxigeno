using Microsoft.EntityFrameworkCore;
using Api_Oxigeno.Config;
using Api_Oxigeno.Servicios;
using Api_Oxigeno.Repositorios;
using System.Text.Json.Serialization;
using Api_Oxigeno.helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

builder.Services.AddControllers()
      .AddJsonOptions(options =>
      {
          options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
      });

builder.Services.AddDbContext<MysqlContext>(option =>
{
    String str_conn = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseMySql(str_conn, ServerVersion.AutoDetect(str_conn));
});

builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<PrescripcionService>();
builder.Services.AddScoped<PacienteRepositorio>();
builder.Services.AddScoped<PrescripcionRepositorio>();

builder.Services.AddAutoMapper(typeof(Program));

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
