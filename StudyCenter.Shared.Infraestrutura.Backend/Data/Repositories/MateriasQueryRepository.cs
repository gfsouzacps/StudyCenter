using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class MateriasQueryRepository : IMateriasQueryRepository
    {
        private readonly StudyCenterDbContext _context;

        public MateriasQueryRepository(StudyCenterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materias>> ObterTodosAsync()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task<Materias> ObterPorIdAsync(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            return materia;
        }

        public async Task<Materias> ObterUltimaMateriaAsync()
        {
            var materia = await _context.Materias.OrderByDescending(m => m.IdMateria).FirstOrDefaultAsync();
            return materia;
        }

        public async Task<IEnumerable<Materias>> ObterMateriasETopicosAsync()
        {
            var materiaETopicos = await _context.Materias.Include(m => m.Topicos).ToListAsync();
            return materiaETopicos;
        }
    }
}
