using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

namespace StudyCenter.API.Controllers
{
    /// <summary>
    /// Controlador para manipulação de tópicos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TopicosController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ITopicosQueryRepository _topicosQueryRepository;
        private readonly ITopicosCommandRepository _topicosCommandRepository;

        /// <summary>
        /// Inicializa uma nova instância do controlador TopicosController.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        /// <param name="topicosQueryRepository">O repositório de consulta de tópicos.</param>
        /// <param name="topicosCommandRepository">O repositório de comandos de tópicos.</param>
        public TopicosController(StudyCenterDbContext context, ITopicosQueryRepository topicosQueryRepository, ITopicosCommandRepository topicosCommandRepository)
        {
            _context = context;
            _topicosQueryRepository = topicosQueryRepository;
            _topicosCommandRepository = topicosCommandRepository;
        }

        /// <summary>
        /// Obtém todos os tópicos.
        /// </summary>
        /// <returns>Retorna uma lista de tópicos.</returns>
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

        /// <summary>
        /// Cria um novo tópico.
        /// </summary>
        /// <param name="topicoViewModel">O modelo de visão do tópico.</param>
        /// <returns>Retorna o tópico criado.</returns>
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

        /// <summary>
        /// Atualiza um tópico existente.
        /// </summary>
        /// <param name="idTopico">O ID do tópico a ser atualizado.</param>
        /// <param name="topicoViewModel">O modelo de visão do tópico.</param>
        /// <returns>Retorna 204 No Content se a atualização for bem-sucedida, 
        /// 400 Bad Request se houver problemas com a solicitação, 
        /// ou 404 Not Found se o tópico não for encontrado.</returns>
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
            try
            {
                var topico = await _topicosQueryRepository.ObterPorIdAsync(idTopico);
                if (topico == null)
                {
                    return NotFound();
                }

                _topicosCommandRepository.Remover(topico);

                return Ok(new { message = "Tópico deletado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar deletar o tópico.");
            }
        }
    }
}