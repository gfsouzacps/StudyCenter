using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class MateriasCommandRepository : IMateriasCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public MateriasCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(Materias Materias)
    {
        _context.Add(Materias);
    }

    public void Atualizar(Materias Materias)
    {
        _context.Materias.Update(Materias);
    }

    public void Remover(Materias Materias)
    {
        _context.Materias.Remove(Materias);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}