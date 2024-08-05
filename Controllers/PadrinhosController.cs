using System;
using System.Reflection.Metadata.Ecma335;
using Data.Mappings;
using ListaCasamento.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Pessoa;
using Models.Pessoa.Noivo;

namespace Controllers
{
    [ApiController]
    public class PadrinhosController : ControllerBase
    {
        [HttpGet("v1/padrinhos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var ConsultaPadrinho = await context.Padrinhos.ToListAsync();

                return Ok(new ResultViewModel<List<Padrinho>>(ConsultaPadrinho));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Padrinho>>("7XCD - Falha Interna no Servidor"));
            }
        }

        [HttpGet("v1/padrinhos/{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var ConsultaPadrinhoID = await context.Padrinhos.FirstOrDefaultAsync(c => c.Id == id);
                if (ConsultaPadrinhoID == null)
                {
                    return NotFound(new ResultViewModel<Padrinho>("8XCD - Conteúdo não encontrado."));
                }
                return Ok(new ResultViewModel<Padrinho>(ConsultaPadrinhoID));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Noivo>("9XCD -Falha Interna no Servidor"));
            }
        }
        [HttpPost("v1/padrinhos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorPessoaViewModel model,
            [FromServices] ListaCasamentoDataContext context
        )
        {
            try
            {
                var padrinho = new Padrinho()
                {
                    Nome = model.Nome,
                    Aniversario = model.Aniversario,
                    Sexo = model.Sexo,
                    Familia = model.Familia,
                    Telefone = model.Telefone,
                    Email = model.Email.ToLower(),
                    Id = Guid.NewGuid()
                };
                await context.Padrinhos.AddAsync(padrinho);
                await context.SaveChangesAsync();
                return Created($"v1/noivos{padrinho.Id}", new ResultViewModel<Padrinho>(padrinho));
            }
            catch
            {
                return StatusCode(500, "10XCD -Não foi possível adicionar um padrinho.");
            }
        }


    }
}