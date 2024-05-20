using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class MateriasRepository : IMateriasRepository
    {
        private readonly StudyCenterDbContext _context;

        public MateriasRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Materias materias)
        {
            _context.Materia.Add(materias);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var materia = await _context.Materia.FindAsync(id);
            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Materias>> GetAllAsync()
        {
            return await _context.Materia.ToListAsync();
        }

        public async Task<Materias> GetByIdAsync(int id)
        {
            var materia = await _context.Materia.FindAsync(id);
            return materia;
        }

        public async Task UpdateAsync(Materias materias)
        {
            _context.Entry(materias).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Materias> GetUltimaMateriaAsync()
        {
            var materia = await _context.Materia.OrderByDescending(m => m.IdMateria).FirstOrDefaultAsync();
            return materia;
        }

        public async Task<IEnumerable<Materias>> GetMateriasETopicosAsync()
        {
            var materiaETopicos = await _context.Materia.Include(m => m.Topicos).ToListAsync();
            return materiaETopicos;
        }
    }
}
