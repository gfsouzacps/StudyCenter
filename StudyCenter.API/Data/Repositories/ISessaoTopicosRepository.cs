using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public interface ISessaoTopicosRepository
    {
        Task<SessaoTopicos> GetByIdAsync(int id);
        Task<IEnumerable<SessaoTopicos>> GetAllAsync();
        Task AddAsync(SessaoTopicos SessaoTopicos);
        Task UpdateAsync(SessaoTopicos SessaoTopicos);
        Task DeleteAsync(int id);
        Task<SessaoTopicos> GetUltimaSessaoTopicosAsync();
    }
}
