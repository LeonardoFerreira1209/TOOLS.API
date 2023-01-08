using APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;

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
    /// Recuperar todos os eventos.
    /// </summary>
    /// <returns></returns>
    Task<List<EventEntity>> GetAllAsync();
}
