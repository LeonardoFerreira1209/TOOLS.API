using DOMAIN.REQUEST;
using DOMAIN.RESPONSE;

namespace INFRAESTRUTURE.FACADES.CEP;

public interface ICepFacade
{
    Task<(bool sucesso, CepResponse response)> GetCep(CepRequest request);
}
