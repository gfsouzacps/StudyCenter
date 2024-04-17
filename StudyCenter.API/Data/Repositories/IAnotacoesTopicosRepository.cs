using StudyCenter.API.Models;

namespace StudyCenter.API.Data.Repositories
{
    public interface IAnotacoesTopicosRepository
    {
        Task<AnotacoesTopicos> GetByIdAsync(int id);
        Task<IEnumerable<AnotacoesTopicos>> GetAllAsync();
        Task AddAsync(AnotacoesTopicos AnotacoesTopicos);
        Task UpdateAsync(AnotacoesTopicos AnotacoesTopicos);
        Task DeleteAsync(int id);
        Task<AnotacoesTopicos> GetUltimaAnotacaoTopicoAsync();
    }
}
