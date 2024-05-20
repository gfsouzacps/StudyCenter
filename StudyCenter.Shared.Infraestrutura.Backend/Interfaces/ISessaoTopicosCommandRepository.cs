using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface ISessaoTopicosCommandRepository
    {
        void Registrar(SessaoTopicos sessaoTopicos);
        void Atualizar(SessaoTopicos sessaoTopicos);
        void Remover(SessaoTopicos sessaoTopicos);
    }
}