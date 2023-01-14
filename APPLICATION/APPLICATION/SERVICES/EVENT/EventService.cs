using APPLICATION.APPLICATION.CONFIGURATIONS;
using APPLICATION.DOMAIN.CONTRACTS.REPOSITORY.EVENT;
using APPLICATION.DOMAIN.CONTRACTS.SERVICES.EVENT;
using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.DTOS.RESPONSE.UTILS;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS.EVENT;
using APPLICATION.DOMAIN.VALIDATORS;
using APPLICATION.ENUMS;
using APPLICATION.INFRAESTRUTURE.SIGNALR.CLIENTS;
using APPLICATION.INFRAESTRUTURE.SIGNALR.HUBS;
using Microsoft.AspNetCore.SignalR;
using Serilog;

namespace APPLICATION.APPLICATION.SERVICES.EVENT;

/// <summary>
/// Serviço de Eventos.
/// </summary>
public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    private readonly IHubContext<HubNotify, INotifyClient> _hubContext;

    public EventService(IEventRepository eventRepository, IHubContext<HubNotify, INotifyClient> hubContext)
    {
        _eventRepository = eventRepository;

        _hubContext = hubContext;
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

            // Validate de eventCreateRequest.
            var validation = await new EventCreateValidator().ValidateAsync(eventCreateRequest); if (validation.IsValid is false) return validation.CarregarErrosValidator();

            Log.Information($"[LOG INFORMATION] - Request validado com sucesso.\n");

            Log.Information($"[LOG INFORMATION] - Criando evento para {eventCreateRequest.FirstName} {eventCreateRequest.LastName}.\n");

            // create event.
            var eventEntity = await _eventRepository.CreateAsync(eventCreateRequest.ToEntity());

            await _hubContext.Clients.All.ReceiveMessage(new INFRAESTRUTURE.SIGNALR.DTOS.Notify("Teste", "Testando")
            {
                Id = new Random().Next(1, 10000),
                Date = DateTime.Now.ToString()
            });

            Log.Information($"[LOG INFORMATION] - Evento Id {eventEntity.Id} criado com sucesso.\n");

            return new ApiResponse<object>(true, StatusCodes.SuccessCreated, eventEntity.ToResponse(), new List<DadosNotificacao> { new DadosNotificacao("Evento criado com sucesso.\n") });
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

            return new ApiResponse<object>(true, StatusCodes.SuccessCreated, eventsEntity.Select(even => even.ToResponse()), new List<DadosNotificacao> { new DadosNotificacao("Eventos recuperados com sucesso.\n") });
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.Message}\n");

            return new ApiResponse<object>(false, StatusCodes.ServerErrorInternalServerError, new List<DadosNotificacao> { new DadosNotificacao(exception.Message) });
        }
    }

    /// <summary>
    /// Método responsável por criar um tipo de evento.
    /// </summary>
    /// <param name="eventTypeCreateRequest"></param>
    /// <returns></returns>
    public async Task<ApiResponse<object>> CreateTypeAsync(EventTypeCreateRequest eventTypeCreateRequest)
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventService)} - METHOD {nameof(CreateTypeAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Validando request.\n");

            // Validate de eventTypeCreateRequest.
            var validation = await new EventTypeCreateValidator().ValidateAsync(eventTypeCreateRequest); if (validation.IsValid is false) return validation.CarregarErrosValidator();

            Log.Information($"[LOG INFORMATION] - Request validado com sucesso.\n");

            Log.Information($"[LOG INFORMATION] - Criando tipo de evento {eventTypeCreateRequest.Name}.\n");

            // create event type.
            var eventTypeEntity = await _eventRepository.CreateTypeAsync(eventTypeCreateRequest.ToEntity());

            Log.Information($"[LOG INFORMATION] - Evento Id {eventTypeEntity.Id} criado com sucesso.\n");

            return new ApiResponse<object>(true, StatusCodes.SuccessCreated, eventTypeEntity.ToResponse(), new List<DadosNotificacao> { new DadosNotificacao("Tipo de evento criado com sucesso.\n") });
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.Message}\n");

            return new ApiResponse<object>(false, StatusCodes.ServerErrorInternalServerError, new List<DadosNotificacao> { new DadosNotificacao(exception.Message) });
        }
    }

    /// <summary>
    /// Método responsável por recuperar todos os tipos de evento.
    /// </summary>
    /// <returns></returns>
    public async Task<ApiResponse<object>> GetAllTypesAsync()
    {
        Log.Information($"[LOG INFORMATION] - SET TITLE {nameof(EventService)} - METHOD {nameof(GetAllTypesAsync)}\n");

        try
        {
            Log.Information($"[LOG INFORMATION] - Recuperando todos os tipos de evento.\n");

            // get all event types in database.
            var eventTypesEntity = await _eventRepository.GetAllTypesAsync();

            Log.Information($"[LOG INFORMATION] - Tipos de evento recuperados com sucesso.\n");

            return new ApiResponse<object>(true, StatusCodes.SuccessCreated, eventTypesEntity.Select(eventype => eventype.ToResponse()), new List<DadosNotificacao> { new DadosNotificacao("Tipos de evento recuperados com sucesso.\n") });
        }
        catch (Exception exception)
        {
            Log.Error($"[LOG ERROR] - {exception.Message}\n");

            return new ApiResponse<object>(false, StatusCodes.ServerErrorInternalServerError, new List<DadosNotificacao> { new DadosNotificacao(exception.Message) });
        }
    }
}
