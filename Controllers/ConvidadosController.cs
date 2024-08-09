using Data.Mappings;
using ListaCasamento.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Pessoa;

namespace Controllers
{
    [ApiController]
    public class ConvidadosController : ControllerBase
    {
        [HttpGet("v1/convidados")]
        public async Task<IActionResult> GetAsync(
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var consultaConvidado = await context.Convidados.ToListAsync();
                return Ok(new ResultViewModel<List<Convidado>>(consultaConvidado));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Convidado>>("14XCD - Falha Interna no Servidor"));
            }
        }
        [HttpGet("v1/convidados/{id:Guid}")]
        public async Task<IActionResult> GetByAsync(
            [FromRoute] Guid id,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var consultaConvidado = await context.Convidados.FirstOrDefaultAsync(c => c.Id == id);
                if (consultaConvidado == null)
                {
                    return NotFound(new ResultViewModel<Convidado>("14XCD - Conteúdo não encontrado."));
                }
                return Ok(new ResultViewModel<Convidado>(consultaConvidado));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Convidado>("15XCD -Falha Interna no Servidor"));
            }
        }
    }
}