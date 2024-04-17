using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Data.Contexts;
using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public class AnotacoesTopicosRepository : IAnotacoesTopicosRepository
    {
        private readonly StudyCenterDbContext _context;

        public AnotacoesTopicosRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AnotacoesTopicos AnotacoesTopicos)
        {
            _context.AnotacoesTopicos.Add(AnotacoesTopicos);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var anotacoesTopico = _context.AnotacoesTopicos.FindAsync(id);
            _context.AnotacoesTopicos.Remove(anotacoesTopico.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnotacoesTopicos>> GetAllAsync()
        {
            return await _context.AnotacoesTopicos.ToListAsync();
        }

        public async Task<AnotacoesTopicos> GetByIdAsync(int id)
        {
            var anotacoesTopico = _context.AnotacoesTopicos.FindAsync(id);
            return await anotacoesTopico;
        }

        public async Task UpdateAsync(AnotacoesTopicos AnotacoesTopicos)
        {
            _context.Entry(AnotacoesTopicos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<AnotacoesTopicos> GetUltimaAnotacaoTopicoAsync() 
        {
            var anotacoesTopico = _context.AnotacoesTopicos.OrderByDescending(m => m.IdAnotacaoTopico).FirstOrDefaultAsync();
            return await anotacoesTopico;
        }
    }
}
