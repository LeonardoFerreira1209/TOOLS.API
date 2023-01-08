using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;
using APPLICATION.DOMAIN.ENTITY.CEP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APPLICATION.INFRAESTRUTURE.CONTEXTO;

/// <summary>
/// Classe de configuração do banco de dados.
/// </summary>
public class Context : DbContext
{
    private readonly IOptions<AppSettings> _appSettings;

    public Context(DbContextOptions<Context> options, IOptions<AppSettings> appsettings) : base(options)
    {
        _appSettings = appsettings;

        Database.EnsureCreated();
    }

    /// <summary>
    /// Sets de tabelas no banco.
    /// </summary>
    public DbSet<CepEntity> Ceps { get; set; }
    public DbSet<EventEntity> Events { get; set; }

    /// <summary>
    /// Métodos responsaveis por configurar o banco de dados.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_appSettings.Value.ConnectionStrings.BaseDados); base.OnConfiguring(optionsBuilder);
    }
}
