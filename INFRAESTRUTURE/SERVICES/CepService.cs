using APPLICATION.INTERFACES.SERVICES;
using DOMAIN.RESPONSE;
using INFRAESTRUTURE.FACADES.CEP;

public class CepService : ICepService
{
    private readonly ICepFacade _cepFacade;

    public CepService(ICepFacade cepFacade)
    {
        _cepFacade = cepFacade;
    }

    public Task<ApiResponse<CepResponse>> GetCep(long cep)
    {
        
    }
}
