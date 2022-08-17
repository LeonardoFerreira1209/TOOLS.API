using APPLICATION.DOMAIN.CONTRACTS.RESPOSITORIES.CEP;
using APPLICATION.DOMAIN.CONTRACTS.SERVICES.CEP;
using APPLICATION.DOMAIN.DTOS.ENTITIES;
using APPLICATION.DOMAIN.DTOS.REQUEST;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS;
using APPLICATION.INFRAESTRUTURE.FACADES.CEP;
using Serilog;
using System.Linq.Expressions;

namespace APPLICATION.APPLICATION.SERVICES.CEP
{
    /// <summary>
    /// Serviço de ceps
    /// </summary>
    public class CepService : ICepService
    {
        private readonly ICepFacade _cepFacade;

        private readonly ICepRepository _cepRepository;

        public CepService(ICepFacade cepFacade, ICepRepository cepRepository)
        {
            _cepFacade = cepFacade;

            _cepRepository = cepRepository;
        }

        /// <summary>
        /// Método responsável por fazer o acesso ao viacep.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CepResponse> GetViaCepGraphQl(CepRequest request)
        {
            Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepService)} - METHOD {nameof(GetViaCepGraphQl)}\n");

            try
            {
                Log.Information($"[LOG INFORMATION] - Fazendo a chamada do {nameof(ICepFacade)}\n");

                var response = await _cepFacade.GetViaCep(request);

                if (response.Sucesso)
                {
                    return response.Dados;
                }

                return null;
            }
            catch (Exception exception)
            {
                Log.Error("[LOG ERROR]", exception, exception.Message);

                return null;
            }
        }

        /// <summary>
        /// Métodos responsavel de fazer o acesso no banco de dados.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CepResponse>> GetWithExpression(Expression<Func<CepEntity, bool>> expression)
        {
            Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepService)} - METHOD {nameof(GetWithExpression)}\n");

            try
            {
                Log.Information($"[LOG INFORMATION] - Fazendo a chamada do {nameof(ICepRepository)}\n");

                var ceps = await _cepRepository.GetWithExpression(expression); return await ceps.ToCepResponse();
            }
            catch (Exception exception)
            {
                Log.Error("[LOG ERROR]", exception, exception.Message);

                return null;
            }
        }
    }
}
