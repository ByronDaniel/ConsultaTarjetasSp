using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Dominio.Interfaces;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProducto7777.Repositorio.Configuraciones.Persistencia
{
    public class BddRepoSitarContext : DbContext
    {
        private readonly string stringConnection;
        public BddRepoSitarContext(string stringConnection)
        {
            this.stringConnection = stringConnection;
        }

        public BddRepoSitarContext(DbContextOptions<BddRepoSitarContext> options) : base(options)
        {

        }

        public DbSet<ConsultarTarjetasCreditoModelo> SpConsultarTarjetasCredito { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(stringConnection);
        }

        internal async Task<List<ConsultarTarjetasCreditoModelo>> BuscarTarjetasCredito(EConsultarTarjetasCreditoBodyIn entrada)
        {
            var identificacion = new SqlParameter("@Identificacion",entrada.Identificacion)
            {
                Direction = ParameterDirection.Input
            };

            var tipoIdentificacion = new SqlParameter("@TipoIdentificacion", entrada.TipoIdentificacion)
            {
                Direction = ParameterDirection.Input
            };

            var result = await SpConsultarTarjetasCredito.FromSqlRaw($"EXECUTE dbo.sp_consultar_tarjetas @Identificacion = {entrada.Identificacion}, @TipoIdentificacion = {entrada.TipoIdentificacion}").ToListAsync();
            return result;
        }

    }
}
