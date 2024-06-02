using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Configurations;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicosController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ITopicosQueryRepository _topicosQueryRepository;

        public TopicosController(StudyCenterDbContext context, ITopicosQueryRepository topicosQueryRepository)
        {
            _context = context;
            _topicosQueryRepository = topicosQueryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topicos>>> GetTopicos()
        {
            var topicos = await _topicosQueryRepository.ObterTodosAsync();
            if (!topicos.Any())
            {
                return NotFound();
            }
            return Ok(topicos);
        }

        [HttpPost]
        public async Task<ActionResult<Topicos>> CriarTopico(TopicosViewModel topicoViewModel)
        {
            var topico = new Topicos
            {
                NomeTopico = topicoViewModel.NomeTopico,
                IdMateria = topicoViewModel.IdMateria
            };

            _context.Topicos.Add(topico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTopicos), new { id = topico.IdTopico }, topico);
        }

        [HttpPut("{idTopico}")]
        public async Task<IActionResult> UpdateTopico(int idTopico, TopicosViewModel topicoViewModel)
        {
            if (idTopico != topicoViewModel.IdTopico)
            {
                return BadRequest();
            }

            var topicoToUpdate = await _context.Topicos.FindAsync(idTopico);

            if (topicoToUpdate == null)
            {
                return NotFound();
            }

            topicoToUpdate.NomeTopico = topicoViewModel.NomeTopico;
            topicoToUpdate.IdMateria = topicoViewModel.IdMateria;

            _context.Entry(topicoToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deleta um tópico e todas as entidades relacionadas a ele.
        /// </summary>
        /// <param name="idTopico">O ID do tópico a ser deletado.</param>
        /// <returns>Retorna 200 OK com uma mensagem de sucesso se a exclusão for bem-sucedida, 
        /// 404 Not Found se o tópico não for encontrado, ou 500 Internal Server Error se ocorrer um erro.</returns>
        [HttpDelete("{idTopico}")]
        public async Task<IActionResult> DeleteTopico(int idTopico)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var topico = await _context.Topicos
                        .Include(t => t.SessaoTopicos)
                            .ThenInclude(st => st.AnotacoesTopicos)
                        .FirstOrDefaultAsync(t => t.IdTopico == idTopico);

                    if (topico == null)
                    {
                        return NotFound();
                    }

                    // Deletar todas as anotacoesTopicos
                    foreach (var sessaoTopico in topico.SessaoTopicos.ToList())
                    {
                        foreach (var anotacaoTopico in sessaoTopico.AnotacoesTopicos.ToList())
                        {
                            _context.AnotacoesTopicos.Remove(anotacaoTopico);
                        }
                        _context.SessaoTopicos.Remove(sessaoTopico);
                    }

                    _context.Topicos.Remove(topico);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new { message = "Tópico deletado com sucesso" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, "Ocorreu um erro ao tentar deletar o tópico.");
                }
            }
        }
    }
}
