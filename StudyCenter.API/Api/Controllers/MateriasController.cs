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

        public MateriasController(StudyCenterDbContext context, MateriasRepository materiasRepository)
        {
            _context = context;
            _materiasRepository = materiasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Materias>> GetMaterias()
        {
            var materias = await _context.Materia.ToListAsync();
            return Ok(materias);
        }

        [HttpPost]
        public async Task<ActionResult<Materias>> CriarMateria(MateriasViewModel materia)
        {
            var ultimaMateria = _materiasRepository.GetUltimaMateriaAsync();
            if (ultimaMateria == null)
            {
                return NotFound();
            }

            var novoId = ultimaMateria.Result.IdMateria + 1;
            var materias = new Materias(novoId, materia.NomeMateria);

            _context.Materia.Add(materias);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CriarMateria), new { id = materia.IdMateria }, materias);
        }

        [HttpDelete]
        public async Task<ActionResult<Materias>> DeletarMateria(int idMateria)
        {
            var materia = await _context.Materia.FindAsync(idMateria);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();

            return materia;
        }
    }
}
