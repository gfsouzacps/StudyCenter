using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Models;

namespace StudyCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly StudyCenterContext _context;

        public MateriasController(StudyCenterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Materias>> GetMaterias()
        {
            var materias = await _context.Materia.ToListAsync();
            return Ok(materias);
        }

        [HttpPost]
        public async Task<ActionResult<Materias>> CriarMateria(Materias materia)
        {
            _context.Materia.Add(materia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateria", new { id = materia.IdMateria }, materia);
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
