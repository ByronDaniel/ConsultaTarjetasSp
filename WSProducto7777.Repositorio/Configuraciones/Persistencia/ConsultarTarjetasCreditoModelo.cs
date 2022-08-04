using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSProducto7777.Repositorio.Configuraciones.Persistencia
{
    public class ConsultarTarjetasCreditoModelo
    {
        [Key] public decimal NUM_TARJETA { get; set; }
        public string NUM_TARJETA_ENMASCARADA { get; set; } = string.Empty;
        public string TIPO_RELACION { get; set; } = string.Empty;
        public string COD_MARCA { get; set; } = string.Empty;
        public string NOMBRE_PRODUCTO { get; set; } = string.Empty;
    }
}
