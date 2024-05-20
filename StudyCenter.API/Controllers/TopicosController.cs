using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Configurations;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

namespace StudyCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicosController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ITopicosQueryRepository _topicosQueryRepository;

        public TopicosController(StudyCenterDbContext context, TopicosQueryRepository topicosQueryRepository)
        {
            _context = context;
            _topicosQueryRepository = topicosQueryRepository;
        }

        [HttpGet]
        [Route("GetTopicos")]
        public async Task<ActionResult<Topicos>> GetTopicos()
        {
            var topicos = _topicosQueryRepository.ObterTodosAsync();
            if (!topicos.Result.Any())
            {
                return NotFound();
            }
            return Ok(topicos.Result);
        }

        [HttpPost]
        [Route("CriarTopico")]
        public async Task<ActionResult<Topicos>> CriarTopico(TopicosViewModel topico) // Criar topico atraves da materia
        {
            var ultimoTopico = _topicosQueryRepository.ObterUltimoTopicoAsync();
            int novoIdTopico = ultimoTopico.Result == null ? 1 : ultimoTopico.Result.IdTopico + 1;

            var topicos = new Topicos(novoIdTopico, topico.NomeTopico, topico.IdMateria);

            _context.Topicos.Add(topicos);
            await _context.SaveChangesAsync();

            var json = JsonHelper.SerializeToJson(topicos);

            return CreatedAtAction(nameof(CriarTopico), new { id = topico.IdTopico }, topicos);
        }

        [HttpDelete]
        [Route("DeletarTopico")]
        public async Task<ActionResult<Topicos>> DeletarTopico(int idTopico)
        {
            var topico = await _context.Topicos.FindAsync(idTopico);
            if (topico == null)
            {
                return NotFound();
            }

            _context.Topicos.Remove(topico);
            await _context.SaveChangesAsync();

            return Ok("Matéria deletada");
        }
    }
}
