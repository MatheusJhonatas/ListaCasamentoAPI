using System.Reflection.Metadata.Ecma335;
using Data.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Pessoa.Noivo;

namespace Controllers
{
    [ApiController]
    public class NoivoController : ControllerBase
    {
        [HttpGet("v1/noivos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] ListaCasamentoDataContext context
        )
        {
            var noivos = await context.Noivos.ToListAsync();
            return Ok(noivos);
        }


        [HttpGet("v1/noivos/{int:id}")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok();
        }
        [HttpPost("v1/noivos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] Noivo noivo,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                await context.Noivos.AddAsync(noivo);
                await context.SaveChangesAsync();

                return Created($"v1/noivos{noivo.Id}", noivo);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível adicionar um noivo(a)");
            }

        }



    }
}


