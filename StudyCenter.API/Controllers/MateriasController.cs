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
        private readonly IMateriasCommandRepository _materiasCommandRepository;
        private readonly ITopicosQueryRepository _topicosQueryRepository;
        private readonly ITopicosCommandRepository _topicosCommandyRepository;

        public MateriasController(StudyCenterDbContext context,
            IMateriasQueryRepository materiasQueryRepository, IMateriasCommandRepository materiasCommandyRepository,
            ITopicosQueryRepository topicosQueryRepository,
            ITopicosCommandRepository topicosCommandRepository)
        {
            _context = context;
            _materiasQueryRepository = materiasQueryRepository;
            _materiasCommandRepository = materiasCommandyRepository;
            _topicosQueryRepository = topicosQueryRepository;
            _topicosCommandyRepository = topicosCommandRepository;
        }

        /// <summary>
        /// Obtém todas as matérias.
        /// </summary>
        /// <returns>Retorna uma lista de matérias.</returns>
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

        /// <summary>
        /// Obtém todas as matérias com os tópicos relacionados.
        /// </summary>
        /// <returns>Retorna uma lista de matérias com os tópicos relacionados.</returns>
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

        /// <summary>
        /// Cria uma nova matéria com tópicos relacionados.
        /// </summary>
        /// <param name="materiaViewModel">O modelo de visão da matéria.</param>
        /// <returns>Retorna a matéria criada.</returns>
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

        /// <summary>
        /// Atualiza uma matéria existente com seus tópicos relacionados.
        /// </summary>
        /// <param name="idMateria">O ID da matéria a ser atualizada.</param>
        /// <param name="materiaViewModel">O modelo de visão da matéria.</param>
        /// <returns>Retorna 204 No Content se a atualização for bem-sucedida, 
        /// 400 Bad Request se houver problemas com a solicitação, 
        /// ou 404 Not Found se a matéria não for encontrada.</returns>
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
            try
            {
                var materia =  await _materiasQueryRepository.ObterMateriasETopicosPorIdAsync(idMateria);
                if (materia == null)
                {
                    return NotFound();
                }

                _materiasCommandRepository.Remover(materia);

                return Ok(new { message = "Matéria deletada com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar deletar a matéria.");
            }
        }
    }
}
