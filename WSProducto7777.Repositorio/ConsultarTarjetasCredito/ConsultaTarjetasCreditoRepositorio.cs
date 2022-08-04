using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Dominio.Interfaces.ConsultarTarjetasCredito;
using WSProducto7777.Entidades;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;
using WSProducto7777.Repositorio.Configuraciones.Persistencia;

namespace WSProducto7777.Repositorio.ConsultarTarjetasCredito
{
    public class ConsultaTarjetasCreditoRepositorio : IConsultaTarjetasCreditoRepositorio
    {
        private readonly string stringConnection;
        public ConsultaTarjetasCreditoRepositorio()
        {
            stringConnection = EConstantes.ConBddTarjetas;
        }

        public WrapperDBContext WrapperDbContext { get; set; } = new WrapperDBContext();

        public async Task<EConsultarTarjetasCreditoBodyOut> EjecutarConsultaTarjetasCredito(EConsultarTarjetasCreditoBodyIn entrada)
        {
            var context = WrapperDbContext.CreateContext(stringConnection);
            ETarjetaBodyOut tarjetaBodyOut;
            var listTarjeta = new List<ETarjetaBodyOut>();

            try
            {
                var resultado = await WrapperDbContext.BuscaTarjetasCredito(context, entrada);

                resultado.ForEach(item =>
                {
                    tarjetaBodyOut = new ETarjetaBodyOut()
                    {
                        CodigoMarca = item.COD_MARCA,
                        NombreProducto = item.NOMBRE_PRODUCTO,
                        NumeroTarjeta = Convert.ToString(item.NUM_TARJETA, CultureInfo.InvariantCulture),
                        NumeroTarjetaEnmascarado = item.NUM_TARJETA_ENMASCARADA,
                        TipoRelacion = item.TIPO_RELACION
                    };
                    listTarjeta.Add(tarjetaBodyOut);
                });
                return new EConsultarTarjetasCreditoBodyOut()
                {
                    Tarjetas = listTarjeta
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                WrapperDbContext.DisposeBdd(context);
            }
        }
    }
}
