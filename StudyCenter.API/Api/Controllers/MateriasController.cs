using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Api.ViewModels;
using StudyCenter.API.Data.Contexts;
using StudyCenter.API.Data.Repositories;
using StudyCenter.API.Models;

namespace StudyCenter.API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly IMateriasRepository _materiasRepository;
        private readonly ITopicosRepository _topicosRepository;

        public MateriasController(StudyCenterDbContext context, MateriasRepository materiasRepository, TopicosRepository topicosRepository)
        {
            _context = context;
            _materiasRepository = materiasRepository;
            _topicosRepository = topicosRepository;
        }

        [HttpGet]
        [Route("GetMaterias")]
        public async Task<ActionResult<Materias>> GetMaterias()
        {
            var materias = _materiasRepository.GetAllAsync();
            if(!materias.Result.Any())
            {
                return NotFound();
            }
            return Ok(materias.Result);
        }

        [HttpPost]
        [Route("CriarMateria")]
        public async Task<ActionResult<Materias>> CriarMateria(MateriasViewModel materiaViewModel)
        {
            var ultimaMateria = _materiasRepository.GetUltimaMateriaAsync();
            int novoIdMateria = ultimaMateria.Result == null ? 1 : ultimaMateria.Result.IdMateria+1;

            var novaMateria = new Materias(novoIdMateria, materiaViewModel.NomeMateria);

            foreach (var topicoViewModel in materiaViewModel.Topicos)
            {
                var ultimoTopico = await _topicosRepository.GetUltimoTopicoAsync();
                int novoIdTopico = ultimoTopico == null ? 1 : ultimoTopico.IdTopico+1;

                var novoTopico = new Topicos(novoIdTopico, topicoViewModel.NomeTopico, novoIdMateria);

                novaMateria.Topicos.Add(novoTopico);
            }

            _context.Materia.Add(novaMateria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CriarMateria), new { id = novaMateria.IdMateria }, novaMateria);
        }

        [HttpDelete]
        [Route("DeletarMateria")]
        public async Task<ActionResult<Materias>> DeletarMateria(int idMateria)
        {
            var materia = await _context.Materia.FindAsync(idMateria);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();

            return Ok("Matéria deletada");
        }
    }
}
