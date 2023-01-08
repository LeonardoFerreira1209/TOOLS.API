using APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;
using APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;
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

    public static EventResponse ToResponse(this EventEntity eventEntity)
    {
        return new EventResponse
        {
            Id = eventEntity.Id,
            FirstName = eventEntity.FirstName,
            LastName = eventEntity.LastName,
            Email = eventEntity.Email,
            Description = eventEntity.Description,
            StartEvent = eventEntity.StartEvent,
            EndEvent = eventEntity.EndEvent,
            CreatedUserId = GlobalData.GlobalUser.Id,
            Created = eventEntity.Created,
            Status = eventEntity.Status,
            Updated = eventEntity.Updated,
            UpdatedUserId = eventEntity.UpdatedUserId,
        };
    }
}
