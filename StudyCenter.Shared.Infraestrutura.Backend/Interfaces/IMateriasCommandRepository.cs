using StudyCenter.Dominio.Entidades.Entities;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories
{
    public interface IMateriasCommandRepository
    {
        void Registrar(Materias materias);
        void Atualizar(Materias materias);
        void Remover(Materias materias);
    }
}