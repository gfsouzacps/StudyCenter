using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class SessaoTopicosQueryRepository : ISessaoTopicosQueryRepository
    {
        private readonly StudyCenterDbContext _context;

        public SessaoTopicosQueryRepository(StudyCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SessaoTopicos>> ObterTodosAsync()
        {
            return await _context.SessaoTopicos.ToListAsync();
        }

        public async Task<SessaoTopicos> ObterPorIdAsync(int id)
        {
            var SessaoTopicos = _context.SessaoTopicos.FindAsync(id);
            return await SessaoTopicos;
        }
        public async Task<SessaoTopicos> ObterUltimaSessaoTopicosAsync()
        {
            var SessaoTopicos = _context.SessaoTopicos.OrderByDescending(m => m.IdSessaoTopico).FirstOrDefaultAsync();
            return await SessaoTopicos;
        }
    }
}
