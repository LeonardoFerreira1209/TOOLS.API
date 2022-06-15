using APPLICATION.APPLICATION.CONFIGURATIONS;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using FluentValidation.Results;

namespace APPLICATION.INFRAESTRUTURE.GRAPHQL.QUERIE;

public abstract class BaseQuery
{
    protected static ApiResponse<CepResponse> CustomValidationCepResponse(ValidationResult validationResult)
    {
        return validationResult.CarregarErrosValidatorCepResponse();
    }
}
