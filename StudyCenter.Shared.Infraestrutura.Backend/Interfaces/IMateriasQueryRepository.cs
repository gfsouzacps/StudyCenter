using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;

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
