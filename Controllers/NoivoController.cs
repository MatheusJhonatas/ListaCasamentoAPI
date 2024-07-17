using System.Reflection.Metadata.Ecma335;
using Data.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.Pessoa.Noivo;

namespace Controllers
{
    [ApiController]
    public class NoivoController : ControllerBase
    {
        [HttpPost("v1/noivos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] Noivo noivo,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            await context.Noivos.AddAsync(noivo);
            await context.SaveChangesAsync();
            return Created($"v1/noivos{noivo.Id}", noivo);
        }

    }
}