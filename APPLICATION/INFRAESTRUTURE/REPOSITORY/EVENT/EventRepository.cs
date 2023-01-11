using APPLICATION.DOMAIN.CONTRACTS.REPOSITORY.EVENT;
using APPLICATION.DOMAIN.DTOS.CONFIGURATION;
using APPLICATION.DOMAIN.ENTITY.EVENT;
using APPLICATION.INFRAESTRUTURE.CONTEXTO;
using APPLICATION.INFRAESTRUTURE.REPOSITORY.BASE;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace APPLICATION.INFRAESTRUTURE.REPOSITORY.EVENT;

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
            return await GetByIdAsync(eventEntity.Id);
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.InnerException} - {exception.Message}\n");

            // retun null value.
            return null;
        }
    }

    /// <summary>
    /// Recuperar evento por Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<EventEntity> GetByIdAsync(Guid id)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventRepository)} - METHOD {nameof(GetByIdAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Recuperando evento por Id.\n");

            // return event by id.
            return await _context.Events.Include(even => even.EventType).FirstOrDefaultAsync(even => even.Id.Equals(id));
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
            Log.Information($"[LOG INFORMATION] - Recuperando todos os eventos.\n");

            // return all events.
            return await _context.Events.Include(even => even.EventType).ToListAsync();
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.InnerException} - {exception.Message}\n");

            // retun null value.
            return null;
        }
    }

    /// <summary>
    /// Criar um tipo de evento na base.
    /// </summary>
    /// <param name="eventTypeEntity"></param>
    /// <returns></returns>
    public async Task<EventTypeEntity> CreateTypeAsync(EventTypeEntity eventTypeEntity)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventRepository)} - METHOD {nameof(CreateTypeAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Criando um novo tipo de evento.\n");

            // create a new event type.
            await _context.EventTypes.AddAsync(eventTypeEntity);

            // save changes.
            await _context.SaveChangesAsync();

            // return event tyoe.
            return eventTypeEntity;
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.InnerException} - {exception.Message}\n");

            // retun null value.
            return null;
        }
    }

    /// <summary>
    /// Recuperar todos os tipos de evento.
    /// </summary>
    /// <returns></returns>
    public async Task<List<EventTypeEntity>> GetAllTypesAsync()
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventRepository)} - METHOD {nameof(GetAllTypesAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Recuperando todos os tipos de evento.\n");

            // return all events.
            return await _context.EventTypes.ToListAsync();
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.InnerException} - {exception.Message}\n");

            // retun null value.
            return null;
        }
    }
}