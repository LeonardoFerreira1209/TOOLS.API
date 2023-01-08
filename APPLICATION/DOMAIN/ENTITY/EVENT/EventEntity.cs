using APPLICATION.DOMAIN.ENTITY.BASE;

namespace APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;

/// <summary>
/// Entidade de eventos.
/// </summary>
public class EventEntity : BaseEntity
{
    /// <summary>
    /// Nome da pessoal para qual o evento foi marcado.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Segundo nome da pessoa.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email da pessoa.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Data & hora de inicio do evento.
    /// </summary>
    public DateTime StartEvent { get; set; }

    /// <summary>
    /// Data & hora do final do evento.
    /// </summary>
    public DateTime EndEvent { get; set; }

    /// <summary>
    /// Descrição do evento.
    /// </summary>
    public string Description { get; set; }
}
