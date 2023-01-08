using APPLICATION.ENUMS;

namespace APPLICATION.DOMAIN.DTOS.RESPONSE.EVENT;

/// <summary>
/// Entidade de eventos.
/// </summary>
public class EventResponse
{
    /// <summary>
    /// Id do evento.
    /// </summary>
    public Guid Id { get; set; }

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
