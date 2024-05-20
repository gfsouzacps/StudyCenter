using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class SessaoTopicosRepository : ISessaoTopicosRepository
    {
        private readonly StudyCenterDbContext _context;

        public SessaoTopicosRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SessaoTopicos SessaoTopicos)
        {
            _context.SessaoTopicos.Add(SessaoTopicos);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var SessaoTopicos = _context.SessaoTopicos.FindAsync(id);
            _context.SessaoTopicos.Remove(SessaoTopicos.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SessaoTopicos>> GetAllAsync()
        {
            return await _context.SessaoTopicos.ToListAsync();
        }

        public async Task<SessaoTopicos> GetByIdAsync(int id)
        {
            var SessaoTopicos = _context.SessaoTopicos.FindAsync(id);
            return await SessaoTopicos;
        }

        public async Task UpdateAsync(SessaoTopicos SessaoTopicos)
        {
            _context.Entry(SessaoTopicos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<SessaoTopicos> GetUltimaSessaoTopicosAsync()
        {
            var SessaoTopicos = _context.SessaoTopicos.OrderByDescending(m => m.IdSessaoTopico).FirstOrDefaultAsync();
            return await SessaoTopicos;
        }
    }
}
