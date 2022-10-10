using APPLICATION.DOMAIN.DTOS.REQUEST;
using APPLICATION.DOMAIN.DTOS.RESPONSE;

namespace APPLICATION.DOMAIN.CONTRACTS.SERVICES.CEP;

/// <summary>
/// Interface de CepSerivce
/// </summary>
public interface ICepService
{
    /// <summary>
    /// Faz uma chamada para o via cep enviando um request
    /// </summary>
    /// <param name="cepRequest"></param>
    /// <returns></returns>
    Task<CepResponse> GetViaCepGraphQl(CepRequest cepRequest);
}
