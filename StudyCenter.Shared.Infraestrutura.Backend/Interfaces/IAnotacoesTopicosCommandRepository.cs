using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface IAnotacoesTopicosCommandRepository
    {
        void Registrar(AnotacoesTopicos anotacoesTopicos);
        void Atualizar(AnotacoesTopicos anotacoesTopicos);
        void Remover(AnotacoesTopicos anotacoesTopicos);
    }
}