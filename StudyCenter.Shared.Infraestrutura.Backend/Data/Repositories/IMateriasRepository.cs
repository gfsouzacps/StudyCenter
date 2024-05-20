using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface IMateriasRepository
    {
        Task<Materias> GetByIdAsync(int id);
        Task<IEnumerable<Materias>> GetAllAsync();
        Task AddAsync(Materias materias);
        Task UpdateAsync(Materias materias);
        Task DeleteAsync(int id);
        Task<Materias> GetUltimaMateriaAsync();
        Task<IEnumerable<Materias>> GetMateriasETopicosAsync();
    }
}
