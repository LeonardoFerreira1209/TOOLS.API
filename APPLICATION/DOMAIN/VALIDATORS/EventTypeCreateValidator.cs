using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS;
using APPLICATION.ENUMS;
using FluentValidation;

namespace APPLICATION.DOMAIN.VALIDATORS;

/// <summary>
/// Validator de Create event type request, verifica se os campos foram informados corretamente.
/// </summary>
public class EventTypeCreateValidator : AbstractValidator<EventTypeCreateRequest>
{
    public EventTypeCreateValidator()
    {
        RuleFor(even => even.Name).NotEmpty().NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());

        RuleFor(even => even.Color).NotEmpty().NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());
    }
}
