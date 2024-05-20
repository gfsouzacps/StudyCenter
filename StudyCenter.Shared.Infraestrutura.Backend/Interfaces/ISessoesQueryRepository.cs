using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface ISessoesQueryRepository
    {
        Task<IEnumerable<Sessoes>> ObterTodosAsync();
        Task<Sessoes> ObterPorIdAsync(int id);
        Task<Sessoes> ObterUltimaSessaoAsync();
    }
}
