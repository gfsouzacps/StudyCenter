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

        [HttpDelete("{idTopico}")]
        public async Task<IActionResult> DeleteTopico(int idTopico)
        {
            var topico = await _context.Topicos.FindAsync(idTopico);
            if (topico == null)
            {
                return NotFound();
            }

            _context.Topicos.Remove(topico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
