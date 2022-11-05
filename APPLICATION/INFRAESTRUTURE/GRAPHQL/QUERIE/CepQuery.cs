using APPLICATION.DOMAIN.CONTRACTS.SERVICES.CEP;
using APPLICATION.DOMAIN.DTOS.REQUEST;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using APPLICATION.DOMAIN.UTILS;
using APPLICATION.DOMAIN.VALIDATORS;
using APPLICATION.INFRAESTRUTURE.GRAPHQL.DATALOADER;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.INFRAESTRUTURE.GRAPHQL.QUERIE;

/// <summary>
/// Método de query de cep
/// </summary>
/// 
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
    /// Query que Recuperar ceps através do Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dataLoader"></param>
    /// <returns></returns>
    [Authorize(Policy = "user")][UsePaging][UseProjection][UseFiltering][UseSorting]
    public async Task<IEnumerable<CepResponse>> WithId(
       [Required] Guid id, GetCepByIdsDataLoader dataLoader) => await Tracker.Time(() => dataLoader.LoadAsync(id), "Recupera ceps através do Id.");

    /// <summary>
    /// Query que Recupera ceps através do codigo postal.
    /// </summary>
    /// <param name="cep"></param>
    /// <param name="dataLoader"></param>
    /// <returns></returns>
    [Authorize(Policy = "user")][UsePaging][UseProjection][UseFiltering][UseSorting]
    public async Task<IEnumerable<CepResponse>> WithCep(
       [Required] string cep, GetCepByCepsDataLoader dataLoader) => await Tracker.Time(() => dataLoader.LoadAsync(cep), "Recupera ceps através do codigo postal.");
}
