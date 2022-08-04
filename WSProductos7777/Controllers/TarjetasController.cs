using Microsoft.AspNetCore.Mvc;
using WSProducto7777.Dominio.Interfaces.ConsultarTarjetasCredito;
using WSProducto7777.Entidades;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProductos7777.API.Controllers
{
    #region DEFINICION DE VERSION DE API
    [ApiVersion("1")]
    #endregion DEFINICION DE VERSION DE API

    [Route("api/[controller]")]
    [ApiController]
    public class TarjetasController : ControllerBase
    {
        public readonly IConsultaTarjetasCreditoInfraestructura iIConsultaTarjetasCreditoInfraestructura;
        public TarjetasController(IConsultaTarjetasCreditoInfraestructura iIConsultaTarjetasCreditoInfraestructura)
        {
            this.iIConsultaTarjetasCreditoInfraestructura = iIConsultaTarjetasCreditoInfraestructura;
        }

        [HttpGet]
        [Route(EConstantes.RecursoConTarCredito01)]
        public ActionResult ConsultarTarjetasCredito()
        {
            return Ok("controlador consulta");
        }

        #region ConsultaTarjetasCredito01 Post

        [HttpPost]
        [Route(EConstantes.RecursoConTarCredito01)]
        public async Task<IActionResult> ConsultaTarjetasCredito(EConsultarTarjetasCreditoBodyIn entrada)
        {

            EConsultarTarjetasCreditoBodyOut salida;
            
            try
            {
                salida = await iIConsultaTarjetasCreditoInfraestructura.EjecutarConsultaTarjetasCredito(entrada);
                return Ok(salida);
            }
            catch (Exception negocioError)
            {
                return BadRequest(negocioError.Message);
            }

        }

        #endregion ConsultaTarjetasCredito01 Post

    }
}
