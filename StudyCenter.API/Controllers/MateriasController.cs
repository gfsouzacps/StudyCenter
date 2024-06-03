using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

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
        private readonly ITopicosCommandRepository _topicosCommandRepository;

        public MateriasController(StudyCenterDbContext context,
            IMateriasQueryRepository materiasQueryRepository, IMateriasCommandRepository materiasCommandRepository,
            ITopicosQueryRepository topicosQueryRepository,
            ITopicosCommandRepository topicosCommandRepository)
        {
            _context = context;
            _materiasQueryRepository = materiasQueryRepository;
            _materiasCommandRepository = materiasCommandRepository;
            _topicosQueryRepository = topicosQueryRepository;
            _topicosCommandRepository = topicosCommandRepository;
        }

        /// <summary>
        /// Obtém todas as matérias.
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de todas as matérias cadastradas no sistema.
        /// </remarks>
        /// <response code="200">Retorna uma lista de todas as matérias.</response>
        /// <response code="404">Se não houver matérias cadastradas.</response>
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
        /// <remarks>
        /// Retorna uma lista de todas as matérias com seus tópicos relacionados.
        /// </remarks>
        /// <response code="200">Retorno bem-sucedido.</response>
        /// <response code="404">Se não houver matérias cadastradas.</response>
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
        /// <remarks>
        /// Cria uma nova matéria no sistema com os tópicos relacionados fornecidos.
        /// </remarks>
        /// <param name="materiaViewModel">Os dados da matéria a serem criada.</param>
        /// <response code="201">Retorna a matéria criada.</response>
        /// <response code="500">Se ocorrer um erro ao tentar criar a matéria.</response>
        [HttpPost]
        public async Task<ActionResult<Materias>> CriarMateria(MateriasViewModel materiaViewModel)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar criar a matéria.");
            }
        }

        /// <summary>
        /// Atualiza uma matéria existente com seus tópicos relacionados.
        /// </summary>
        /// <remarks>
        /// Atualiza uma matéria existente no sistema com os novos dados fornecidos.
        /// </remarks>
        /// <param name="idMateria">O ID da matéria a ser atualizada.</param>
        /// <param name="materiaViewModel">Os novos dados da matéria.</param>
        /// <response code="204">Atualização bem-sucedida.</response>
        /// <response code="400">Se o ID da matéria não corresponder ao ID fornecido.</response>
        /// <response code="404">Se a matéria não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro ao tentar atualizar a matéria.</response>
        [HttpPut("{idMateria}")]
        public async Task<IActionResult> UpdateMateria(int idMateria, MateriasViewModel materiaViewModel)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar atualizar a matéria.");
            }
        }

        /// <summary>
        /// Deleta uma matéria e todas as entidades relacionadas a ela.
        /// </summary>
        /// <remarks>
        /// Deleta uma matéria e todos os seus tópicos relacionados do sistema.
        /// </remarks>
        /// <param name="idMateria">O ID da matéria a ser deletada.</param>
        /// <response code="200">Matéria deletada com sucesso.</response>
        /// <response code="404">Se a matéria não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro ao tentar deletar a matéria.</response>
        [HttpDelete("{idMateria}")]
        public async Task<IActionResult> DeleteMateria(int idMateria)
        {
            try
            {
                var materia = await _materiasQueryRepository.ObterMateriasETopicosPorIdAsync(idMateria);
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