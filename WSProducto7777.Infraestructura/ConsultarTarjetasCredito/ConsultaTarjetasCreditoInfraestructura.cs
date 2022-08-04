using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Dominio.Interfaces.ConsultarTarjetasCredito;
using WSProducto7777.Dominio.Interfaces.Validaciones.ConsultarTarjetasCredito;
using WSProducto7777.Entidades;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProducto7777.Infraestructura.ConsultarTarjetasCredito
{
    public class ConsultaTarjetasCreditoInfraestructura : IConsultaTarjetasCreditoInfraestructura
    {
        public readonly IConsultaTarjetasCreditoRepositorio consultaTarjetasCreditoRepositorio;
        private readonly IValidaEntradaConsultaTarjetasCredito iValidatorConsultarTarjetasCredito;

        public ConsultaTarjetasCreditoInfraestructura(IConsultaTarjetasCreditoRepositorio consultaTarjetasCreditoRepositorio, IValidaEntradaConsultaTarjetasCredito iValidatorConsultarTarjetasCredito)
        {
            this.consultaTarjetasCreditoRepositorio = consultaTarjetasCreditoRepositorio;
            this.iValidatorConsultarTarjetasCredito = iValidatorConsultarTarjetasCredito;

        }
        public async Task<EConsultarTarjetasCreditoBodyOut> EjecutarConsultaTarjetasCredito(EConsultarTarjetasCreditoBodyIn entrada)
        {

            (var cumpleValidacion, var codigo, var mensaje) =
               await iValidatorConsultarTarjetasCredito.ValidarEntrada(entrada);

            if (!cumpleValidacion)
                throw new ArgumentException($"{codigo} - {mensaje}");

            return await consultaTarjetasCreditoRepositorio.EjecutarConsultaTarjetasCredito(entrada);
        }
    }
}
