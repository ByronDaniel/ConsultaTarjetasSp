using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProducto7777.Dominio.Interfaces.ConsultarTarjetasCredito
{
    public interface IConsultaTarjetasCreditoInfraestructura
    {
        Task<EConsultarTarjetasCreditoBodyOut> EjecutarConsultaTarjetasCredito(EConsultarTarjetasCreditoBodyIn entrada);
    }
}
