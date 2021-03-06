using APPLICATION.DOMAIN.CONTRACTS.API;
using APPLICATION.DOMAIN.DTOS.REQUEST;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using Newtonsoft.Json;
using Serilog;

namespace APPLICATION.INFRAESTRUTURE.FACADES.CEP;

/// <summary>
/// Classe responsavel por fazer a chamada para o viaCep.
/// </summary>
public class CepFacade : ICepFacade
{
    private readonly ICepExternal _cepExternal;

    public CepFacade(ICepExternal cepExternal)
    {
        _cepExternal = cepExternal;
    }

    /// <summary>
    /// Faz chamada para o viaCep através do REFIT.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<ApiResponse<CepResponse>> GetViaCep(CepRequest request)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepFacade)} - METHOD {nameof(GetViaCep)}\n");

        try
        {
            var (sucesso, response) = await ResponseCep(request);

            if (sucesso)
            {
                return new ApiResponse<CepResponse>(sucesso, response);
            }
            else
            {
                return new ApiResponse<CepResponse>(sucesso, new List<DadosNotificacao> { new DadosNotificacao(DOMAIN.ENUM.StatusCodes.ErrorBadRequest, "Via cep retorno sem sucesso") });
            }
        }
        catch (Exception exception)
        {
            Log.Error("[LOG ERROR]", exception, exception.Message);

            return new ApiResponse<CepResponse>(false, new List<DadosNotificacao> { new DadosNotificacao(DOMAIN.ENUM.StatusCodes.ServerErrorInternalServerError, exception.Message) });
        }
    }

    private async Task<(bool sucesso, CepResponse response)> ResponseCep(CepRequest request)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepFacade)} - METHOD {nameof(ResponseCep)}\n");

        try
        {
            var response = await _cepExternal.Get(request.Cep);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Log.Information($"[LOG INFORMATION] - Resposta da consulta do CEP : {request.Cep} - Content: {content}");

                return (true, JsonConvert.DeserializeObject<CepResponse>(content));
            }
            else
            {
                Log.Warning($"[LOG WARNING] - Não foi possivel realizar a consulta do CEP : {request.Cep}");

                return (false, null);
            }
        }
        catch (Exception exception)
        {
            Log.Error("[LOG ERROR]", exception.Message);

            return (false, null);
        }
    }
}
