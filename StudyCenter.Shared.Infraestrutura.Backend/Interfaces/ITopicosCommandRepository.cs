using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface ITopicosCommandRepository
    {
        void Registrar(Topicos topicos);
        void Atualizar(Topicos topicos);
        void Remover(Topicos topicos);
    }
}