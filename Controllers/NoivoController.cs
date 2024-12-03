using System.Reflection.Metadata.Ecma335;
using Data.Mappings;
using ListaCasamento.ViewModels;
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
            try
            {
                var noivos = await context.Noivos.ToListAsync();
                return Ok(new ResultViewModel<List<Noivo>>(noivos));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Noivo>>("0XCD - Falha Interna no Servidor"));
            }
        }


        [HttpGet("v1/noivos/{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var noivos = await context.Noivos.FirstOrDefaultAsync(c => c.Id == id);
                if (noivos == null)
                {
                    return NotFound(new ResultViewModel<Noivo>("1XCD - Conteúdo não encontrado."));
                }
                return Ok(new ResultViewModel<Noivo>(noivos));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Noivo>("2XCD -Falha Interna no Servidor"));
            }
        }
        [HttpPost("v1/noivos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorPessoaViewModel model,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var noivo = new Noivo
                {
                    Nome = model.Nome,
                    Aniversario = model.Aniversario,
                    Sexo = model.Sexo,
                    Familia = model.Familia,
                    Telefone = model.Telefone,
                    Email = model.Email.ToLower(),

                };
                await context.Noivos.AddAsync(noivo);
                await context.SaveChangesAsync();

                return Created($"v1/noivos{noivo.Id}", new ResultViewModel<Noivo>(noivo));
            }
            catch (Exception e)
            {
                return StatusCode(500, "3XCD -Não foi possível adicionar um noivo(a)");
            }

        }

        [HttpDelete("v1/noivos/{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] Guid id,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var deletarNoivo = context.Noivos.FirstOrDefault(c => c.Id == id);
                if (deletarNoivo == null)
                {
                    return NotFound(new ResultViewModel<Noivo>("4XCD - ID do noivo não encontrado"));
                }
                context.Noivos.Remove(deletarNoivo);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<Noivo>(deletarNoivo + $"Usuário {deletarNoivo.Nome} foi excluido com sucesso"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Noivo>("5XCD - Falha interna no servidor"));
            }
        }


        [HttpPut("v1/noivos/{id:Guid}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] Guid id,
            [FromBody] EditorPessoaViewModel model,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var atualizaNoivo = await context.Noivos.FirstOrDefaultAsync(c => c.Id == id);
                if (atualizaNoivo == null)
                {
                    return NotFound();
                }

                atualizaNoivo.Nome = model.Nome;
                atualizaNoivo.Aniversario = model.Aniversario;
                atualizaNoivo.Sexo = model.Sexo;
                atualizaNoivo.Familia = model.Familia;
                atualizaNoivo.Telefone = model.Telefone;
                atualizaNoivo.Email = model.Email.ToLower();


                context.Update(atualizaNoivo);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Noivo>(atualizaNoivo));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Noivo>("6XCD - Falha Interna no Servidor"));
            }
        }


    }
}


