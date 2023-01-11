using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;
using APPLICATION.DOMAIN.ENTITY.EVENT;
using APPLICATION.DOMAIN.UTILS.GLOBAL;
using APPLICATION.ENUMS;

namespace APPLICATION.DOMAIN.UTILS.EXTENSIONS.EVENT;

/// <summary>
/// extensão de ventos
/// </summary>
public static class EventExtensions
{
    /// <summary>
    /// Converte um event create para um eventEntity.
    /// </summary>
    /// <param name="eventCreateRequest"></param>
    /// <returns></returns>
    public static EventEntity ToEntity(this EventCreateRequest eventCreateRequest)
    {
        return new EventEntity
        {
            EventTypeId = eventCreateRequest.EventTypeId,
            FirstName = eventCreateRequest.FirstName,
            LastName = eventCreateRequest.LastName,
            Email = eventCreateRequest.Email,
            Description = eventCreateRequest.Description,
            StartEvent = eventCreateRequest.StartEvent,
            EndEvent = eventCreateRequest.EndEvent,
            CreatedUserId = GlobalData.GlobalUser.Id,
            Created = DateTime.Now,
            Status = Status.Active
        };
    }

    /// <summary>
    /// Converte um eventEntity para um eventResponse.
    /// </summary>
    /// <param name="eventEntity"></param>
    /// <returns></returns>
    public static EventResponse ToResponse(this EventEntity eventEntity)
    {
        return new EventResponse
        {
            Id = eventEntity.Id,
            EventTypeId = eventEntity.EventTypeId,
            EventType = eventEntity.EventType?.ToResponse(),
            FirstName = eventEntity.FirstName,
            LastName = eventEntity.LastName,
            Email = eventEntity.Email,
            Description = eventEntity.Description,
            StartEvent = eventEntity.StartEvent,
            EndEvent = eventEntity.EndEvent,
            CreatedUserId = eventEntity.CreatedUserId,
            Created = eventEntity.Created,
            Status = eventEntity.Status,
            Updated = eventEntity.Updated,
            UpdatedUserId = eventEntity.UpdatedUserId,
        };
    }

    /// <summary>
    /// Converte um eventtypecreate para um eventtypeentity.
    /// </summary>
    /// <param name="eventTypeCreateRequest"></param>
    /// <returns></returns>
    public static EventTypeEntity ToEntity(this EventTypeCreateRequest eventTypeCreateRequest)
    {
        return new EventTypeEntity
        {
            Name = eventTypeCreateRequest.Name,
            Color = eventTypeCreateRequest.Color,
            CreatedUserId = GlobalData.GlobalUser.Id,
            Created = DateTime.Now,
            Status = Status.Active
        };
    }

    /// <summary>
    /// Convert um eventtypeentity em um eventtyperesponse.
    /// </summary>
    /// <param name="eventTypeEntity"></param>
    /// <returns></returns>
    public static EventTypeResponse ToResponse(this EventTypeEntity eventTypeEntity)
    {
        return new EventTypeResponse
        {
            Id = eventTypeEntity.Id,
            Color = eventTypeEntity.Color,
            Created = eventTypeEntity.Created,
            Status = eventTypeEntity.Status,
            CreatedUserId= eventTypeEntity.CreatedUserId,
            Name = eventTypeEntity.Name,
            Updated = eventTypeEntity.Updated,
            UpdatedUserId = eventTypeEntity.UpdatedUserId,
        };
    }
}
