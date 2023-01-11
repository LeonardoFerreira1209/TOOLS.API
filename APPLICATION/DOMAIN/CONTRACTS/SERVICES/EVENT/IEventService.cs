using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.DTOS.RESPONSE.UTILS;

namespace APPLICATION.DOMAIN.CONTRACTS.SERVICES.EVENT;

/// <summary>
/// Interface de serviço eventos.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Método responsável por criar um evento.
    /// </summary>
    /// <param name="eventCreateRequest"></param>
    /// <returns></returns>
    Task<ApiResponse<object>> CreateAsync(EventCreateRequest eventCreateRequest);

    /// <summary>
    /// Método responsável por recuperar todos os eventos.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponse<object>> GetAllAsync();

    /// <summary>
    /// Método responsável por criar um tipo de evento.
    /// </summary>
    /// <param name="eventTypeCreateRequest"></param>
    /// <returns></returns>
    Task<ApiResponse<object>> CreateTypeAsync(EventTypeCreateRequest eventTypeCreateRequest);

    /// <summary>
    /// Método responsável por recuperar todos os tipos de evento.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponse<object>> GetAllTypesAsync();
}
