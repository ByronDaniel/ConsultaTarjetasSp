using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProducto7777.Dominio.Interfaces.Validaciones.ConsultarTarjetasCredito;
using WSProducto7777.Entidades;
using WSProducto7777.Entidades.ConsultarTarjetasCredito;

namespace WSProducto7777.Infraestructura.Validaciones
{
    public class ValidaEntradaConsultaTarjetasCredito : IValidaEntradaConsultaTarjetasCredito
    {
        public async Task<(bool cumple, string codigo, string mensaje)> ValidarEntrada(
           EConsultarTarjetasCreditoBodyIn entrada)
        {
            (var cumpleNulos, var codigoNulos, var mensajeNulos) = ValidarNulos(entrada);
            if (!cumpleNulos)
                return (false, codigoNulos, mensajeNulos);

            (var cumpleRequeridos, var codigoRequeridos, var mensajeRequeridos) = await ValidarRequeridos(entrada);
            if (!cumpleRequeridos)
                return (false, codigoRequeridos, mensajeRequeridos);

            return (true, EConstantes.CodOk, EConstantes.Ok);
        }

        private (bool cumple, string codigo, string mensaje) ValidarNulos(
            EConsultarTarjetasCreditoBodyIn entrada)
        {

            if (entrada == null || entrada.Equals(default(EConsultarTarjetasCreditoBodyIn)))
                return (false, EConstantes.Cod0002, EConstantes.DesMensajeBody);

            if (entrada == null) return (false, EConstantes.Cod0003, EConstantes.DesMsjBodyMsj);

            return (true, EConstantes.CodOk, EConstantes.Ok);
        }

        private async Task<(bool cumple, string codigo, string mensaje)> ValidarRequeridos(
            EConsultarTarjetasCreditoBodyIn entrada)
        {
            var validationRules = new DatosEntradaValidacion();
            var result = await validationRules.ValidateAsync(entrada);

            if (!result.IsValid)
            {
                var errorList = (List<ValidationFailure>)result.Errors;
                return (false, $"{errorList[0].ErrorCode}",
                    $"{errorList[0].PropertyName} : {errorList[0].ErrorMessage}");
            }

            return (true, EConstantes.CodOk, EConstantes.Ok);
        }
    }

    public class DatosEntradaValidacion : AbstractValidator<EConsultarTarjetasCreditoBodyIn>
    {
        public DatosEntradaValidacion()
        {
            RuleFor(solicitud => solicitud.TipoIdentificacion)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage(EConstantes.NuloVacio)
                .WithErrorCode(EConstantes.Cod0004)
                .NotEmpty()
                .WithMessage(EConstantes.NuloVacio)
                .WithErrorCode(EConstantes.Cod0004)
                .MaximumLength(4).WithMessage($"{EConstantes.DesMsjMaxLen1} 4 {EConstantes.DesMsjMaxLen2}")
                .WithErrorCode(EConstantes.Cod0006);

            RuleFor(solicitud => solicitud.Identificacion)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage(EConstantes.NuloVacio)
                .WithErrorCode(EConstantes.Cod0004)
                .NotEmpty().WithMessage(EConstantes.NuloVacio)
                .WithErrorCode(EConstantes.Cod0004)
                .MaximumLength(20)
                .WithMessage($"{EConstantes.DesMsjMaxLen1} 20 {EConstantes.DesMsjMaxLen2}")
                .WithErrorCode(EConstantes.Cod0006)
                .Matches(EConstantes.RegexString).WithMessage(EConstantes.DesMsjSpclCarac)
                .WithErrorCode(EConstantes.Cod0007);
        }
    }
}

