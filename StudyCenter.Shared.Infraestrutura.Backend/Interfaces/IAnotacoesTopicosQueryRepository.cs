using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface IAnotacoesTopicosQueryRepository
    {
        Task<AnotacoesTopicos> ObterPorIdAsync(int id);
        Task<IEnumerable<AnotacoesTopicos>> ObterTodosAsync();
        Task<AnotacoesTopicos> ObterUltimaAnotacaoTopicoAsync();
    }
}