using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public class AnotacoesTopicosQueryRepository : IAnotacoesTopicosQueryRepository
    {
        private readonly StudyCenterDbContext _context;

        public AnotacoesTopicosQueryRepository(StudyCenterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnotacoesTopicos>> ObterTodosAsync()
        {
            return await _context.AnotacoesTopicos.ToListAsync();
        }

        public async Task<AnotacoesTopicos> ObterPorIdAsync(int id)
        {
            var anotacoesTopico = _context.AnotacoesTopicos.FindAsync(id);
            return await anotacoesTopico;
        }

        public async Task<AnotacoesTopicos> ObterUltimaAnotacaoTopicoAsync()
        {
            var anotacoesTopico = _context.AnotacoesTopicos.OrderByDescending(m => m.IdAnotacaoTopico).FirstOrDefaultAsync();
            return await anotacoesTopico;
        }
    }
}
