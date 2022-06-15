using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using APPLICATION.DOMAIN.DTOS.ENTITIES;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APPLICATION.INFRAESTRUTURE.CONTEXTO;

/// <summary>
/// Classe de configuração do banco de dados.
/// </summary>
public class Contexto : DbContext
{
    private readonly IOptions<AppSettings> _appSettings;

    public Contexto(DbContextOptions<Contexto> options, IOptions<AppSettings> appsettings) : base(options)
    {
        _appSettings = appsettings;

        Database.EnsureCreated();
    }

    /// <summary>
    /// Sets de tabelas no banco.
    /// </summary>
    #region  DbSet's

    #region C
    public DbSet<CepEntity> Ceps { get; set; }
    #endregion

    #endregion

    /// <summary>
    /// Métodos responsaveis por configurar o banco de dados.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    #region Métodos override
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_appSettings.Value.ConnectionStrings.BaseDados);

        base.OnConfiguring(optionsBuilder);
    }
    #endregion
}
