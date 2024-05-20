using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public interface ISessoesRepository
    {
        Task<Sessoes> GetByIdAsync(int id);
        Task<IEnumerable<Sessoes>> GetAllAsync();
        Task AddAsync(Sessoes sessoes);
        Task UpdateAsync(Sessoes sessoes);
        Task DeleteAsync(int id);
        Task<Sessoes> GetUltimaSessaoAsync();
    }
}
