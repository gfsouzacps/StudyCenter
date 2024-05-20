using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface ISessaoTopicosQueryRepository
    {
        Task<IEnumerable<SessaoTopicos>> ObterTodosAsync();
        Task<SessaoTopicos> ObterPorIdAsync(int id);
        Task<SessaoTopicos> ObterUltimaSessaoTopicosAsync();
    }
}
