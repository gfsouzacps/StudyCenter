using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface ITopicosQueryRepository
    {
        Task<IEnumerable<Topicos>> ObterTodosAsync();
        Task<Topicos> ObterPorIdAsync(int id);
        Task<Topicos> ObterUltimoTopicoAsync();
    }
}
