using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS;
using APPLICATION.ENUMS;
using FluentValidation;

namespace APPLICATION.DOMAIN.VALIDATORS;

/// <summary>
/// Validator de Create event request, verifica se os campos foram informados corretamente.
/// </summary>
public class EventCreateValidator : AbstractValidator<EventCreateRequest>
{
    public EventCreateValidator()
    {
        RuleFor(even => even.FirstName).NotEmpty().NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());

        RuleFor(even => even.LastName).NotEmpty().NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());

        RuleFor(even => even.Email).NotEmpty().NotNull().EmailAddress().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());

        RuleFor(even => even.StartEvent).NotEmpty().NotNull().Must(StartDateValidade).WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());

        RuleFor(even => even).NotEmpty().NotNull().Must(EndDateValidade).WithErrorCode(ErrorCode.CamposObrigatorios.ToCode());
    }

    /// <summary>
    /// Valida se a data de inicio é maior ou igual a data atual.
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    private static bool StartDateValidade(DateTime startDate) => startDate > DateTime.Now;

    /// <summary>
    /// Valida se a data de fim é maior que a data de inicio.
    /// </summary>
    /// <param name="endDate"></param>
    /// <returns></returns>
    private static bool EndDateValidade(EventCreateRequest eventCreateRequest) => eventCreateRequest.EndEvent > eventCreateRequest.StartEvent;
}
