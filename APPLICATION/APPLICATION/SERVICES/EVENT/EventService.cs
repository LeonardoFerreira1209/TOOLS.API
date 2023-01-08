using APPLICATION.APPLICATION.CONFIGURATIONS;
using APPLICATION.DOMAIN.CONTRACTS.REPOSITORY.EVENT;
using APPLICATION.DOMAIN.CONTRACTS.SERVICES.EVENT;
using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.DTOS.RESPONSE.UTILS;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS.EVENT;
using APPLICATION.DOMAIN.VALIDATORS;
using APPLICATION.ENUMS;
using Serilog;

namespace APPLICATION.APPLICATION.SERVICES.EVENT;

/// <summary>
/// Serviço de Eventos.
/// </summary>
public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    /// <summary>
    /// Método responsável por criar um evento.
    /// </summary>
    /// <param name="eventCreateRequest"></param>
    /// <returns></returns>
    public async Task<ApiResponse<object>> CreateAsync(EventCreateRequest eventCreateRequest)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventService)} - METHOD {nameof(CreateAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Validando request.\n");

            // Validate de userRequest.
            var validation = await new EventCreateValidator().ValidateAsync(eventCreateRequest); if (validation.IsValid is false) return validation.CarregarErrosValidator();

            Log.Information($"[LOG INFORMATION] - Request validado com sucesso.\n");

            Log.Information($"[LOG INFORMATION] - Criando evento para {eventCreateRequest.FirstName} {eventCreateRequest.LastName}.\n");

            // create event.
            var eventEntity = await _eventRepository.CreateAsync(eventCreateRequest.ToEntity());

            Log.Information($"[LOG INFORMATION] - Evento Id {eventEntity.Id} criado com sucesso.\n");

            return new ApiResponse<object>(true, StatusCodes.SuccessCreated, eventEntity.ToResponse(), new List<DadosNotificacao> { new DadosNotificacao("evento criado com sucesso.\n") });
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.Message}\n");

            return new ApiResponse<object>(false, StatusCodes.ServerErrorInternalServerError, new List<DadosNotificacao> { new DadosNotificacao(exception.Message) });
        }
    }

    /// <summary>
    /// Método responsável por recuperar todos os eventos.
    /// </summary>
    /// <returns></returns>
    public async Task<ApiResponse<object>> GetAllAsync()
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventService)} - METHOD {nameof(GetAllAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Recuperando todos os eventos.\n");

            // get all events in database.
            var eventsEntity = await _eventRepository.GetAllAsync();

            Log.Information($"[LOG INFORMATION] - Eventos recuperados com sucesso.\n");

            return new ApiResponse<object>(true, StatusCodes.SuccessCreated, eventsEntity.Select(even => even.ToResponse()), new List<DadosNotificacao> { new DadosNotificacao("eventos recuperados com sucesso.\n") });
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.Message}\n");

            return new ApiResponse<object>(false, StatusCodes.ServerErrorInternalServerError, new List<DadosNotificacao> { new DadosNotificacao(exception.Message) });
        }
    }
}
