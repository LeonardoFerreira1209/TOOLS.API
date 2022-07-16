using APPLICATION.DOMAIN.DTOS.ENTITIES;
using System.Linq.Expressions;

namespace APPLICATION.DOMAIN.CONTRACTS.RESPOSITORIES.CEP;

/// <summary>
/// Interface de Cep Repository
/// </summary>
public interface ICepRepository
{
    /// <summary>
    /// Chamada da função para retornar todos os registros da base.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CepEntity>> GetWithExpression(Expression<Func<CepEntity, bool>> expression);
}
