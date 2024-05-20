using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
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
