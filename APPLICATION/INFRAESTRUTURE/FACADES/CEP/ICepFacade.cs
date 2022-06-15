using APPLICATION.DOMAIN.DTOS.REQUEST;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using Microsoft.AspNetCore.Mvc;

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
