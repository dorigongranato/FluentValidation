using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.APi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] Usuario usuario)
    {
        return Ok();
    }
}