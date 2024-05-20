using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class SessoesQueryRepository : ISessoesQueryRepository
    {
        private readonly StudyCenterDbContext _context;

        public SessoesQueryRepository(StudyCenterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sessoes>> ObterTodosAsync()
        {
            return await _context.Sessoes.ToListAsync();
        }

        public async Task<Sessoes> ObterPorIdAsync(int id)
        {
            var sessao = _context.Sessoes.FindAsync(id);
            return await sessao;
        }
        public async Task<Sessoes> ObterUltimaSessaoAsync()
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
