using APPLICATION.CONTRACTS.API;
using DOMAIN.REQUEST;
using DOMAIN.RESPONSE;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace INFRAESTRUTURE.FACADES.CEP;

public class CepFacade : ICepFacade
{
    private readonly ICepExternal _cepExternal;
    private ILogger _logger;

    public CepFacade(ICepExternal cepExternal, ILogger<CepFacade> logger)
    {
        _cepExternal = cepExternal;

        _logger = logger;
    }

    public async Task<(bool sucesso, CepResponse response)> GetCep(CepRequest request)
    {
        _logger.LogInformation("CepFacade - method: GetCep");
        try
        {
            _logger.LogInformation("Iniciando requisição para o Get");

            var response = JsonSerializer.Deserialize<CepResponse>(await _cepExternal.Get(request.Cep).Result.Content.ReadAsStringAsync());

            _logger.LogInformation($"A requisição para o CEP: {request.Cep} foi feita com sucesso. Content: {response}.");

            return (true, response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Aplicação finalizou com erro.", ex);

            return (false, null);
        }
    }
}
