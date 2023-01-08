using APPLICATION.APPLICATION.CONFIGURATIONS;
using APPLICATION.DOMAIN.DTOS.RESPONSE.UTILS;
using FluentValidation.Results;

namespace APPLICATION.INFRAESTRUTURE.GRAPHQL.QUERIE;

public abstract class BaseQuery
{
    protected static ApiResponse<object> CustomValidationCepResponse(ValidationResult validationResult)
    {
        return validationResult.CarregarErrosValidator();
    }
}
