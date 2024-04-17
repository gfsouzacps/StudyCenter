using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public interface ITopicosRepository
    {
        Task<Topicos> GetByIdAsync(int id);
        Task<IEnumerable<Topicos>> GetAllAsync();
        Task AddAsync(Topicos topicos);
        Task UpdateAsync(Topicos topicos);
        Task DeleteAsync(int id);
        Task<Topicos> GetUltimoTopicoAsync();
    }
}
