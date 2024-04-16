using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public interface IMateriasRepository
    {
        Task<Materias> GetByIdAsync(int id);
        Task<IEnumerable<Materias>> GetAllAsync();
        Task AddAsync(Materias materias);
        Task UpdateAsync(Materias materias);
        Task DeleteAsync(int id);
    }
}
