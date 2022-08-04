using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSProducto7777.Entidades.ConsultarTarjetasCredito
{
    public class ETarjetaBodyOut
    {
        public string NumeroTarjeta { get; set; } = string.Empty;
        public string NumeroTarjetaEnmascarado { get; set; } = string.Empty;
        public string TipoRelacion { get; set; } = string.Empty;
        public string CodigoMarca { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
    }
}
