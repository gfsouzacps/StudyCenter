using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class SessoesCommandRepository : ISessoesCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public SessoesCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(Sessoes sessoes)
    {
        _context.Add(sessoes);
    }

    public void Atualizar(Sessoes sessoes)
    {
        _context.Sessoes.Update(sessoes);
    }

    public void Remover(Sessoes sessoes)
    {
        _context.Sessoes.Remove(sessoes);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}