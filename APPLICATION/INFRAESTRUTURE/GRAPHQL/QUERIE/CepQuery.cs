using APPLICATION.DOMAIN.CONTRACTS.SERVICES.CEP;
using APPLICATION.DOMAIN.DTOS.REQUEST;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using APPLICATION.DOMAIN.UTILS;
using APPLICATION.DOMAIN.VALIDATORS;
using Microsoft.AspNetCore.Cors;
using Serilog;

namespace APPLICATION.INFRAESTRUTURE.GRAPHQL.QUERIE;

/// <summary>
/// Método de query de cep
/// </summary>
[EnableCors("CorsPolicy")]
public class CepQuery : BaseQuery
{
    /// <summary>
    /// Query que faz a chamada no via cep.
    /// </summary>
    /// <param name="cepService"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<CepResponse> ViaCep([Service] ICepService cepService, CepRequest request)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepQuery)} - METHOD {nameof(ViaCep)}\n");

        var validation = await new CepValidator().ValidateAsync(request);

        Log.Information($"[LOG INFORMATION] - Validando dados do {typeof(CepRequest)}.\n");

        if (!validation.IsValid) throw new InvalidOperationException("Dados do CEP inválidos.");

        return await Tracker.Time(() => cepService.GetViaCepGraphQl(request), "Buscar CEP no viaCep.");
    }

    /// <summary>
    /// Query que faz acesso ao banco de dados.
    /// </summary>
    /// <param name="cepService"></param>
    /// <returns></returns>
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<ICollection<CepResponse>> All([Service] ICepService cepService)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepQuery)} - METHOD {nameof(All)}\n");

        return await Tracker.Time(() => cepService.All(), "Buscar CEP no banco de dados.");
    }
}
