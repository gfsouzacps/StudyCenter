using Microsoft.AspNetCore.Mvc;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Configurations;
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
        private readonly ITopicosQueryRepository _topicosQueryRepository;

        public MateriasController(StudyCenterDbContext context, MateriasQueryRepository materiasQueryRepository,
            TopicosQueryRepository topicosQueryRepository)
        {
            _context = context;
            _materiasQueryRepository = materiasQueryRepository;
            _topicosQueryRepository = topicosQueryRepository;
        }

        [HttpGet]
        [Route("GetMaterias")]
        public async Task<ActionResult<Materias>> GetMaterias()
        {
            var materias = await _materiasQueryRepository.ObterTodosAsync();
            if (!materias.Any())
            {
                return NotFound();
            }
            return Ok(materias);
        }

        [HttpGet]
        [Route("GetMateriasETopicos")]
        public async Task<ActionResult<MateriasViewModel>> GetMateriasETopicos()
        {
            var materias = await _materiasQueryRepository.ObterMateriasETopicosAsync();
            if (!materias.Any())
            {
                return NotFound();
            }
            return Ok(materias);
        }

        [HttpPost]
        [Route("CriarMateria")]
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

            return CreatedAtAction(nameof(CriarMateria), new { id = novaMateria.IdMateria }, novaMateria);
        }


        [HttpDelete]
        [Route("DeletarMateria")]
        public async Task<ActionResult<Materias>> DeletarMateria(int idMateria)
        {
            var materia = await _context.Materias.FindAsync(idMateria);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return Ok("Matéria deletada");
        }
    }
}
