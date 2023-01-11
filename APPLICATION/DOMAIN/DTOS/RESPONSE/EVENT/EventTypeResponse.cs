using APPLICATION.ENUMS;

namespace APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;

/// <summary>
/// Entidade de eventos.
/// </summary>
public class EventTypeResponse
{
    /// <summary>
    /// Id do tipo de evento.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nome do tipo.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Cor do tipo.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Data de criação
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Data de atualização
    /// </summary>
    public DateTime? Updated { get; set; }

    /// <summary>
    /// Usuário de cadastro.
    /// </summary>
    public Guid CreatedUserId { get; set; }

    /// <summary>
    /// Usuário que atualizou.
    /// </summary>
    public Guid? UpdatedUserId { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public Status Status { get; set; }
}
