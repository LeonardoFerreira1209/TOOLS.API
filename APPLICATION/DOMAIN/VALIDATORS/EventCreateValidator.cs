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
        RuleFor(even => even.EventTypeId).NotEmpty().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o tipo!").NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o tipo!");

        RuleFor(even => even.FirstName).NotEmpty().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o nome!").NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o nome!");

        RuleFor(even => even.LastName).NotEmpty().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o sobrenome!").NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o sobrenome!");

        RuleFor(even => even.Email).NotEmpty().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o email!").NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o email!").EmailAddress().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha o email corretamente!");

        RuleFor(even => even.StartEvent).NotEmpty().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha a data de inicio!").NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha a data de inicio!").Must(StartDateValidade).WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Data de inicio não pode ser menor que a atual!");

        RuleFor(even => even).NotEmpty().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha a data de fim!").NotNull().WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Preencha a data de fim!").Must(EndDateValidade).WithErrorCode(ErrorCode.CamposObrigatorios.ToCode()).WithMessage("Data de fim deve ser maior que a de inicio!");
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
