using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;

namespace StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
public class SessaoTopicosCommandRepository : ISessaoTopicosCommandRepository
{
    private readonly StudyCenterDbContext _context;

    public SessaoTopicosCommandRepository(StudyCenterDbContext context)
    {
        _context = context;
    }

    public void Registrar(SessaoTopicos sessaoTopicos)
    {
        _context.Add(sessaoTopicos);
    }

    public void Atualizar(SessaoTopicos sessaoTopicos)
    {
        _context.SessaoTopicos.Update(sessaoTopicos);
    }

    public void Remover(SessaoTopicos sessaoTopicos)
    {
        _context.SessaoTopicos.Remove(sessaoTopicos);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}