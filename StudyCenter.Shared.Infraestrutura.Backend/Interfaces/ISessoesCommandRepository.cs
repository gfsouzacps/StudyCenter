using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface ISessoesCommandRepository
    {
        void Registrar(Sessoes sessoes);
        void Atualizar(Sessoes sessoes);
        void Remover(Sessoes sessoes);
    }
}