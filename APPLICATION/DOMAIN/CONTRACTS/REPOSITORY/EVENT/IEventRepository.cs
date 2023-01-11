using APPLICATION.DOMAIN.ENTITY.EVENT;

namespace APPLICATION.DOMAIN.CONTRACTS.REPOSITORY.EVENT;

/// <summary>
/// Interface de eventos.
/// </summary>
public interface IEventRepository
{
    /// <summary>
    /// Cria um novo evento.
    /// </summary>
    /// <param name="eventEntity"></param>
    /// <returns></returns>
    Task<EventEntity> CreateAsync(EventEntity eventEntity);

    /// <summary>
    /// Recuperar evento por Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<EventEntity> GetByIdAsync(Guid id);

    /// <summary>
    /// Recuperar todos os eventos.
    /// </summary>
    /// <returns></returns>
    Task<List<EventEntity>> GetAllAsync();

    /// <summary>
    /// Cria um novo tipo de evento.
    /// </summary>
    /// <param name="eventTypeEntity"></param>
    /// <returns></returns>
    Task<EventTypeEntity> CreateTypeAsync(EventTypeEntity eventTypeEntity);

    /// <summary>
    /// Recuperar todos os tipos de evento.
    /// </summary>
    /// <returns></returns>
    Task<List<EventTypeEntity>> GetAllTypesAsync();
}
