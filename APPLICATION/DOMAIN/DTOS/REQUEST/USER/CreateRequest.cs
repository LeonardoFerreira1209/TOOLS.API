using Microsoft.AspNetCore.Identity;

namespace APPLICATION.DOMAIN.DTOS.REQUEST.USER
{
    /// <summary>
    /// Classe de criação de usuário herdada de IdentityUser.
    /// </summary>
    public class CreateRequest : IdentityUser<Guid> { }
}
