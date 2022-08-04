using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProducto7777.Repositorio.Configuraciones.Persistencia
{
    public class WrapperDBContext
    {
        public virtual BddRepoSitarContext CreateContext(string stringConnection)
        {
            return new BddRepoSitarContext(stringConnection);
        }

        public virtual async Task<List<ConsultarTarjetasCreditoModelo>> BuscaTarjetasCredito(BddRepoSitarContext bdd, EConsultarTarjetasCreditoBodyIn entrada)
        {
            return await bdd.BuscarTarjetasCredito(entrada);
        }

        public void DisposeBdd(BddRepoSitarContext bdd)
        {
            if (bdd != null)
            {
                bdd.Dispose();
            }
        }
    }
}
