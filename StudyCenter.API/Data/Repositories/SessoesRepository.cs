using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Data.Contexts;
using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public class SessoesRepository : ISessoesRepository
    {
        private readonly StudyCenterDbContext _context;

        public SessoesRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Sessoes sessoes)
        {
            _context.Sessoes.Add(sessoes);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var sessao = _context.Sessoes.FindAsync(id);
            _context.Sessoes.Remove(sessao.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sessoes>> GetAllAsync()
        {
            return await _context.Sessoes.ToListAsync();
        }

        public async Task<Sessoes> GetByIdAsync(int id)
        {
            var sessao = _context.Sessoes.FindAsync(id);
            return await sessao;
        }

        public async Task UpdateAsync(Sessoes sessoes)
        {
            _context.Entry(sessoes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Sessoes> GetUltimaSessaoAsync() 
        {
            var sessao = _context.Sessoes.OrderByDescending(m => m.IdSessao).FirstOrDefaultAsync();
            return await sessao;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
