using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class TopicosRepository : ITopicosRepository
    {
        private readonly StudyCenterDbContext _context;

        public TopicosRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Topicos topicos)
        {
            _context.Topicos.Add(topicos);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var topico = _context.Topicos.FindAsync(id);
            _context.Topicos.Remove(topico.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Topicos>> GetAllAsync()
        {
            return await _context.Topicos.ToListAsync();
        }

        public async Task<Topicos> GetByIdAsync(int id)
        {
            var topico = _context.Topicos.FindAsync(id);
            return await topico;
        }

        public async Task UpdateAsync(Topicos topicos)
        {
            _context.Entry(topicos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Topicos> GetUltimoTopicoAsync()
        {
            var topico = _context.Topicos.OrderByDescending(m => m.IdTopico).FirstOrDefaultAsync();
            return await topico;
        }
    }
}
