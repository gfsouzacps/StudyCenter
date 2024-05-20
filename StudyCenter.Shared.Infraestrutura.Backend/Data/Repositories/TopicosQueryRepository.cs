using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class TopicosQueryRepository : ITopicosQueryRepository
    {
        private readonly StudyCenterDbContext _context;

        public TopicosQueryRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Topicos>> ObterTodosAsync()
        {
            return await _context.Topicos.ToListAsync();
        }

        public async Task<Topicos> ObterPorIdAsync(int id)
        {
            var topico = _context.Topicos.FindAsync(id);
            return await topico;
        }

        public async Task<Topicos> ObterUltimoTopicoAsync()
        {
            var topico = _context.Topicos.OrderByDescending(m => m.IdTopico).FirstOrDefaultAsync();
            return await topico;
        }
    }
}
