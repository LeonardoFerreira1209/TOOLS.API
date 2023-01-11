using APPLICATION.DOMAIN.ENTITY.BASE;

namespace APPLICATION.DOMAIN.ENTITY.EVENT;

/// <summary>
/// Entidade de evento tipo.
/// </summary>
public class EventTypeEntity : BaseEntity
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
