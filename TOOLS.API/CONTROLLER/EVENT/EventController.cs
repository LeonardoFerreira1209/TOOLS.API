using APPLICATION.DOMAIN.CONTRACTS.SERVICES.EVENT;
using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.DTOS.RESPONSE.UTILS;
using APPLICATION.DOMAIN.UTILS;
using APPLICATION.DOMAIN.UTILS.AUTH.CUSTOMAUTHORIZE.ATTRIBUTE;
using APPLICATION.ENUMS;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Context;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace TOOLS.API.CONTROLLER.CALENDAR;

[Route("api/[controller]")][ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService) { _eventService = eventService; }

    /// <summary>
    ///  Método responsavel por criar evento do calendário.
    /// </summary>
    /// <param name="eventCreateRequest"></param>
    /// <returns></returns>
    [HttpPost("create")][CustomAuthorize(Claims.Event, "Post")][EnableCors("CorsPolicy")]
    [SwaggerOperation(Summary = "Criar evento.", Description = "Método responsavel por criar eventos do calendário.")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse<object>> CreateEvent(EventCreateRequest eventCreateRequest)
    {
        using (LogContext.PushProperty("Controller", "EventController"))
        using (LogContext.PushProperty("Payload", JsonConvert.SerializeObject(eventCreateRequest)))
        using (LogContext.PushProperty("Metodo", "CreateEvent"))
        {
            return await Tracker.Time(() => _eventService.CreateAsync(eventCreateRequest), "Criar evemto");
        }
    }

    /// <summary>
    /// Método responsavel por recuperar eventos do calendário.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getall")][CustomAuthorize(Claims.Event, "Get")][EnableCors("CorsPolicy")]
    [SwaggerOperation(Summary = "Recuperar eventos.", Description = "Método responsavel por recuperar eventos do calendário.")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse<object>> GetEvents()
    {
        using (LogContext.PushProperty("Controller", "EventController"))
        using (LogContext.PushProperty("Metodo", "GetEvents"))
        {
            return await Tracker.Time(() => _eventService.GetAllAsync(), "Recuperar eventos");
        }
    }

    /// <summary>
    ///  Método responsavel por criar tipos de evento do calendário.
    /// </summary>
    /// <param name="eventTypeCreateRequest"></param>
    /// <returns></returns>
    [HttpPost("create/eventype")][CustomAuthorize(Claims.Event, "Post")][EnableCors("CorsPolicy")]
    [SwaggerOperation(Summary = "Criar tipo de evento.", Description = " Método responsavel por criar tipos de evento do calendário.")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse<object>> CreateEventType(EventTypeCreateRequest eventTypeCreateRequest)
    {
        using (LogContext.PushProperty("Controller", "EventController"))
        using (LogContext.PushProperty("Payload", JsonConvert.SerializeObject(eventTypeCreateRequest)))
        using (LogContext.PushProperty("Metodo", "CreateEventType"))
        {
            return await Tracker.Time(() => _eventService.CreateTypeAsync(eventTypeCreateRequest), "Criar tipo de evento");
        }
    }

    /// <summary>
    /// Método responsavel por recuperar tipos de evento do calendário.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getall/eventtypes")][CustomAuthorize(Claims.Event, "Get")][EnableCors("CorsPolicy")]
    [SwaggerOperation(Summary = "Recuperar tipos de evento.", Description = "Método responsavel por recuperar tipos de evento do calendário.")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
    public async Task<ApiResponse<object>> GetEventTypes()
    {
        using (LogContext.PushProperty("Controller", "EventController"))
        using (LogContext.PushProperty("Metodo", "GetEventTypes"))
        {
            return await Tracker.Time(() => _eventService.GetAllTypesAsync(), "Recuperar tipos de evento");
        }
    }
}
