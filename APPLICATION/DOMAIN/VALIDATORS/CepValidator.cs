using APPLICATION.DOMAIN.DTOS.REQUEST.CEP;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS;
using APPLICATION.ENUMS;
using FluentValidation;

namespace APPLICATION.DOMAIN.VALIDATORS;

/// <summary>
/// Validator de cep, verifica se os campos foram informados corretamente.
/// </summary>
public class CepValidator : AbstractValidator<CepRequest>
{
    public CepValidator()
    {
        RuleFor(c => c.Cep).NotEmpty().NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());
    }
}
