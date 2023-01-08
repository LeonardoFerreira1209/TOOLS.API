using APPLICATION.DOMAIN.CONTRACTS.REPOSITORY.EVENT;
using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;
using APPLICATION.INFRAESTRUTURE.CONTEXTO;
using APPLICATION.INFRAESTRUTURE.REPOSITORY.BASE;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace APPLICATION.INFRAESTRUTURE.REPOSITORY.PLAN;

[ExcludeFromCodeCoverage]
public class EventRepository : BaseRepository, IEventRepository
{
    private readonly Context _context;

    public EventRepository(Context context, IOptions<AppSettings> appssetings) : base(appssetings)
    {
        _context = context;
    }

    /// <summary>
    /// Criar um evento na base.
    /// </summary>
    /// <param name="eventEntity"></param>
    /// <returns></returns>
    public async Task<EventEntity> CreateAsync(EventEntity eventEntity)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventRepository)} - METHOD {nameof(CreateAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Criando um novo evento.\n");

            // create a new event.
            await _context.Events.AddAsync(eventEntity);

            // save changes.
            await _context.SaveChangesAsync();

            // return event.
            return eventEntity;
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.InnerException} - {exception.Message}\n");

            // retun null value.
            return null;
        }
    }

    /// <summary>
    /// Recuperar todos os eventos.
    /// </summary>
    /// <returns></returns>
    public async Task<List<EventEntity>> GetAllAsync()
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventRepository)} - METHOD {nameof(GetAllAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Recuperando todos os eventos evento.\n");

            // return all events.
            return await _context.Events.ToListAsync();
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.InnerException} - {exception.Message}\n");

            // retun null value.
            return null;
        }
    }
}