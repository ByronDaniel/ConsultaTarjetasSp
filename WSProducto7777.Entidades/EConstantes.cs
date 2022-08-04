using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSProducto7777.Entidades
{
    public static class EConstantes
    {
        #region Servicio

        #region ConsultarTarjetasCredito
        public const string RecursoConTarCredito01 = "ConsultaTarjetasCredito01";
        public const string ConBddTarjetas = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bptarjetas;Integrated Security=True";

        #endregion ConsultarTarjetasCredito

        #endregion Servicio

        #region Comun

        public const string Ok = "OK";
        public const string CodOk = "0";
        public const string ValExpCodigoOp = "9998";
        public const string ValExpCodigo = "9999";
        public const string RegexString = @"^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ_0-9\r\s\n\{\}\/\-\?\:\(\)\.\,\'\+\&\\]*$";
        public const string RegexInt = @"^[0-9]*$";

        #endregion

        #region Validaciones

        public const string Cod0001 = "0001";
        public const string DesMensajeHeader = "El Header del servicio es nulo o no existe";
        public const string Cod0002 = "0002";
        public const string DesMensajeBody = "El body del servicio es nulo o no existe";
        public const string NuloVacio = "nulo o vacio";
        public const string Cod0003 = "0003";
        public const string Cod0004 = "0004";
        public const string Cod0006 = "0006";
        public const string Cod0007 = "0007";
        public const string DesMsjBodyMsj = "El bodyIn.mensaje del servicio es nulo o vacio o no existe";


        public const string DesMsjMaxLen1 = "debe tener maximo";
        public const string DesMsjMaxLen2 = "caracteres";
        public const string DesMsjSpclCarac = "no debe tener caracteres especiales";
        public const string TagSpConTarjeta = "SpCommandConsultarTarjetas";
        public const int Zero = 0;
        public const string Vacio = " ";

        #endregion
    }
}
