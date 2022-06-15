using APPLICATION.DOMAIN.CONTRACTS.RESPOSITORIES.CEP;
using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using APPLICATION.DOMAIN.DTOS.ENTITIES;
using APPLICATION.INFRAESTRUTURE.CONTEXTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

namespace APPLICATION.INFRAESTRUTURE.REPOSITORY;

/// <summary>
/// Classe que faz acesso a tabela de Cep no banco de dados.
/// </summary>
public class CepRepository : ICepRepository
{
    private readonly DbContextOptions<Contexto> _dbContextOptions;

    private readonly IOptions<AppSettings> _appSettings;

    public CepRepository(IOptions<AppSettings> appSettings)
    {
        _dbContextOptions = new DbContextOptions<Contexto>();

        _appSettings = appSettings;
    }

    /// <summary>
    /// Método responsavel por retornar todos os ceps da base.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CepEntity>> All()
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(CepRepository)} - METHOD {nameof(All)}\n");

        return await new Contexto(_dbContextOptions, _appSettings).Ceps.ToListAsync();
    }
}
