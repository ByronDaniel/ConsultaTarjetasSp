using WSProducto7777.Dominio.Interfaces.ConsultarTarjetasCredito;
using WSProducto7777.Dominio.Interfaces.Validaciones.ConsultarTarjetasCredito;
using WSProducto7777.Infraestructura.ConsultarTarjetasCredito;
using WSProducto7777.Infraestructura.Validaciones;
using WSProducto7777.Repositorio.ConsultarTarjetasCredito;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
#region INFRAESTRUCTURA
builder.Services.AddScoped<IConsultaTarjetasCreditoInfraestructura, ConsultaTarjetasCreditoInfraestructura>();
builder.Services.AddScoped<IConsultaTarjetasCreditoRepositorio, ConsultaTarjetasCreditoRepositorio>();
builder.Services.AddScoped<IValidaEntradaConsultaTarjetasCredito, ValidaEntradaConsultaTarjetasCredito>();
#endregion INFRAESTRUCTURA



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

app.UseAuthorization();

app.MapControllers();

app.Run();
