using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Data.Contexts;
using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
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
            var materia = _context.Materia.FindAsync(id);
            _context.Materia.Remove(materia.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Materias>> GetAllAsync()
        {
            return await _context.Materia.ToListAsync();
        }

        public async Task<Materias> GetByIdAsync(int id)
        {
            var materia = _context.Materia.FindAsync(id);
            return await materia;
        }

        public async Task UpdateAsync(Materias materias)
        {
            _context.Entry(materias).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Materias> GetUltimaMateriaAsync() 
        {
            var materia = _context.Materia.OrderByDescending(m => m.IdMateria).FirstOrDefaultAsync();
            return await materia;
        }
    }
}
