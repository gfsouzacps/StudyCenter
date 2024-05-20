using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface IMateriasQueryRepository
    {
        Task<IEnumerable<Materias>> ObterTodosAsync();
        Task<Materias> ObterPorIdAsync(int id);
        Task<Materias> ObterUltimaMateriaAsync();
        Task<IEnumerable<Materias>> ObterMateriasETopicosAsync();
    }
}
