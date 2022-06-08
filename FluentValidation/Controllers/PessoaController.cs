using FluentValidation.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.APi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
    
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            return Ok();
        }

    }
