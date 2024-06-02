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
    public class MateriasController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly IMateriasQueryRepository _materiasQueryRepository;
        private readonly ITopicosQueryRepository _topicosQueryRepository;

        public MateriasController(StudyCenterDbContext context,
            IMateriasQueryRepository materiasQueryRepository,
            ITopicosQueryRepository topicosQueryRepository)
        {
            _context = context;
            _materiasQueryRepository = materiasQueryRepository;
            _topicosQueryRepository = topicosQueryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materias>>> GetMaterias()
        {
            var materias = await _materiasQueryRepository.ObterTodosAsync();
            if (!materias.Any())
            {
                return NotFound();
            }
            return Ok(materias);
        }

        [HttpGet("materia-com-topicos")]
        public async Task<ActionResult<IEnumerable<MateriasViewModel>>> GetMateriasETopicos()
        {
            var materias = await _materiasQueryRepository.ObterMateriasETopicosAsync();
            if (!materias.Any())
            {
                return NotFound();
            }
            return Ok(materias);
        }

        [HttpPost]
        public async Task<ActionResult<Materias>> CriarMateria(MateriasViewModel materiaViewModel)
        {
            var novaMateria = new Materias
            {
                NomeMateria = materiaViewModel.NomeMateria
            };

            _context.Materias.Add(novaMateria);
            await _context.SaveChangesAsync();

            foreach (var topicoViewModel in materiaViewModel.Topicos)
            {
                var novoTopico = new Topicos
                {
                    NomeTopico = topicoViewModel.NomeTopico,
                    IdMateria = novaMateria.IdMateria
                };

                novaMateria.Topicos.Add(novoTopico);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMaterias), new { id = novaMateria.IdMateria }, novaMateria);
        }

        [HttpPut("{idMateria}")]
        public async Task<IActionResult> UpdateMateria(int idMateria, MateriasViewModel materiaViewModel)
        {
            if (idMateria != materiaViewModel.IdMateria)
            {
                return BadRequest();
            }

            var materiaToUpdate = await _context.Materias.Include(m => m.Topicos)
                                                         .FirstOrDefaultAsync(m => m.IdMateria == idMateria);

            if (materiaToUpdate == null)
            {
                return NotFound();
            }

            materiaToUpdate.NomeMateria = materiaViewModel.NomeMateria;

            // Update Topicos
            materiaToUpdate.Topicos.Clear();
            foreach (var topicoViewModel in materiaViewModel.Topicos)
            {
                var novoTopico = new Topicos
                {
                    NomeTopico = topicoViewModel.NomeTopico,
                    IdMateria = materiaToUpdate.IdMateria
                };
                materiaToUpdate.Topicos.Add(novoTopico);
            }

            _context.Entry(materiaToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{idMateria}")]
        public async Task<IActionResult> DeleteMateria(int idMateria)
        {
            var materia = await _context.Materias.FindAsync(idMateria);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
