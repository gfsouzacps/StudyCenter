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
        private readonly ITopicosCommandRepository _topicosCommandyRepository;

        public MateriasController(StudyCenterDbContext context,
            IMateriasQueryRepository materiasQueryRepository,
            ITopicosQueryRepository topicosQueryRepository,
            ITopicosCommandRepository topicosCommandRepository)
        {
            _context = context;
            _materiasQueryRepository = materiasQueryRepository;
            _topicosQueryRepository = topicosQueryRepository;
            _topicosCommandyRepository = topicosCommandRepository;
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

        /// <summary>
        /// Deleta uma matéria e todas as entidades relacionadas a ela.
        /// </summary>
        /// <param name="idMateria">O ID da matéria a ser deletada.</param>
        /// <returns>Retorna 200 OK com uma mensagem de sucesso se a exclusão for bem-sucedida, 
        /// 404 Not Found se a matéria não for encontrada, ou 500 Internal Server Error se ocorrer um erro.</returns>
        [HttpDelete("{idMateria}")]
        public async Task<IActionResult> DeleteMateria(int idMateria)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var materia = await _materiasQueryRepository.ObterMateriasETopicosPorIdAsync(idMateria);
                    if (materia == null)
                    {
                        return NotFound();
                    }

                    var topicos = materia.Topicos.ToList();
                    foreach (var topico in topicos)
                    {
                        var sessaoTopicos = await _context.SessaoTopicos.Where(st => st.IdTopico == topico.IdTopico).ToListAsync();
                        foreach (var sessaoTopico in sessaoTopicos)
                        {
                            var anotacoesTopicos = await _context.AnotacoesTopicos.Where(at => at.IdSessaoTopico == sessaoTopico.IdSessaoTopico).ToListAsync();
                            foreach (var anotacaoTopico in anotacoesTopicos)
                            {
                                _context.AnotacoesTopicos.Remove(anotacaoTopico);
                            }
                            _context.SessaoTopicos.Remove(sessaoTopico);
                        }
                        _context.Topicos.Remove(topico);
                    }

                    _context.Materias.Remove(materia);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new { message = "Matéria deletada com sucesso" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, "Ocorreu um erro ao tentar deletar a matéria.");
                }
            }
        }
    }
}