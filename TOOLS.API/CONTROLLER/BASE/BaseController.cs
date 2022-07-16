using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TOOLS.API.CONTROLLER.BASE;

[Route("api/[controller]")] [ApiController]
public class BaseController : ControllerBase
{
    [Authorize] [HttpOptions("/options")]
    public async Task<IActionResult> Options()
    {
        return await Task.FromResult(Ok("Retorno das options da aplicação!"));
    }
}
