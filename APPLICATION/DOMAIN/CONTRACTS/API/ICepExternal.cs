using Refit;

namespace APPLICATION.DOMAIN.CONTRACTS.API;

/// <summary>
/// Interface de chamada do ViaCep com Refit.
/// </summary>
public interface ICepExternal
{
    /// <summary>
    /// Chamada para o viaCep
    /// </summary>
    /// <param name="cep"></param>
    /// <returns></returns>
    [Get("/{cep}/json/")]
    Task<HttpResponseMessage> Get(long cep);
}
