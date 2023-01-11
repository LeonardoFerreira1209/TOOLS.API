namespace APPLICATION.DOMAIN.DTOS.REQUEST.EVENT;

public class EventTypeCreateRequest
{
    /// <summary>
    /// Nome do tipo.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Cor do tipo.
    /// </summary>
    public string Color { get; set; }
}