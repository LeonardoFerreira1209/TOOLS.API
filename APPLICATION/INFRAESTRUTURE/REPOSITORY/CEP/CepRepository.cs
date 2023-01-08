using APPLICATION.DOMAIN.CONTRACTS.REPOSITORY.CEP;
using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using APPLICATION.DOMAIN.ENTITY.CEP;
using APPLICATION.INFRAESTRUTURE.CONTEXTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Linq.Expressions;

namespace APPLICATION.INFRAESTRUTURE.REPOSITORY.CEP;

/// <summary>
/// Classe que faz acesso a tabela de Cep no banco de dados.
/// </summary>
public class CepRepository : ICepRepository
{
    private readonly DbContextOptions<Context> _dbContextOptions;

    private readonly IOptions<AppSettings> _appSettings;

    public CepRepository(IOptions<AppSettings> appSettings)
    {
        _dbContextOptions = new DbContextOptions<Context>();

        _appSettings = appSettings;
    }

    /// <summary>
    /// Método responsavel por retornar todos os ceps da base.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CepEntity>> GetWithExpression(Expression<Func<CepEntity, bool>> expression)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepRepository)} - METHOD {nameof(GetWithExpression)}\n");

        return await new Context(_dbContextOptions, _appSettings).Ceps.Where(expression).ToArrayAsync();
    }
}
