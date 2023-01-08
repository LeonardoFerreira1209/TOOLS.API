using APPLICATION.DOMAIN.DTOS.REQUEST.CEP;
using APPLICATION.DOMAIN.DTOS.RESPONSE.CEP;
using APPLICATION.DOMAIN.DTOS.RESPONSE.UTILS;

namespace APPLICATION.INFRAESTRUTURE.FACADES.CEP;

public interface ICepFacade
{
    /// <summary>
    /// Faz a chamada para o ViaCep.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ApiResponse<CepResponse>> GetViaCep(CepRequest request);
}
