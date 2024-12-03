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
        public async Task<IActionResult> GetByIdAsync(
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
        [HttpPost("v1/convidados")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorPessoaViewModel model,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var convidado = new Convidado
                {
                    Confirmacao = model.Confirmacao,
                    Nome = model.Nome,
                    Aniversario = model.Aniversario,
                    Sexo = model.Sexo,
                    Familia = model.Familia,
                    Telefone = model.Telefone,
                    Email = model.Email.ToLower(),

                };

                await context.Convidados.AddAsync(convidado);
                await context.SaveChangesAsync();
                return Created($"v1/convidados{convidado.Id}", new ResultViewModel<Convidado>(convidado));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Convidado>("16XCD -Falha Interna no Servidor"));
            }
        }

        [HttpDelete("v1/convidados/{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] Guid id,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var deletarConvidado = context.Convidados.FirstOrDefault(c => c.Id == id);
                if (deletarConvidado == null)
                {
                    return NotFound(new ResultViewModel<Convidado>("17XCD - ID do convidado não encontrado"));
                }
                context.Convidados.Remove(deletarConvidado);
                await context.SaveChangesAsync();
                return Ok($" Usuário {deletarConvidado.Nome} foi excluido com sucesso");
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Convidado>("18XCD - Falha interna no servidor"));
            }
        }


        [HttpPut("v1/convidados/{id:Guid}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] Guid id,
            [FromBody] EditorPessoaViewModel model,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var atualizaConvidado = await context.Convidados.FirstOrDefaultAsync(c => c.Id == id);
                if (atualizaConvidado == null)
                {
                    return NotFound();
                }
                atualizaConvidado.Confirmacao = model.Confirmacao;
                atualizaConvidado.Nome = model.Nome;
                atualizaConvidado.Aniversario = model.Aniversario;
                atualizaConvidado.Sexo = model.Sexo;
                atualizaConvidado.Familia = model.Familia;
                atualizaConvidado.Telefone = model.Telefone;
                atualizaConvidado.Email = model.Email.ToLower();


                context.Update(atualizaConvidado);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Convidado>(atualizaConvidado));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Convidado>("19XCD - Falha Interna no Servidor"));
            }
        }
    }
}