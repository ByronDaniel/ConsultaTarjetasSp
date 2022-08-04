using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProducto7777.Dominio.Interfaces.Validaciones.ConsultarTarjetasCredito
{
    public interface IValidaEntradaConsultaTarjetasCredito
    {
        Task<(bool cumple, string codigo, string mensaje)> ValidarEntrada(EConsultarTarjetasCreditoBodyIn entrada);
    }
}
